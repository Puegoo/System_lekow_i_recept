using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using BCrypt.Net;

namespace PillPal
{
    public partial class Form_Farmaceuta : UserControl
    {
        private DatabaseService databaseService;
        private AccountType_Form_Register parentFormRegister;

        public Form_Farmaceuta(AccountType_Form_Register parentFormRegister)
        {
            InitializeComponent();
            DataUrodzeniaDateTimePicker.MaxDate = DateTime.Now;
            PlecComboBox.Items.Add("Kobieta");
            PlecComboBox.Items.Add("Mężczyzna");
            PlecComboBox.SelectedIndex = 0;

            databaseService = new DatabaseService();
            this.parentFormRegister = parentFormRegister;

            FillComboBoxes();
        }

        private async void ZarejestrujButton_Click(object sender, EventArgs e)
        {
            string login = LoginTextBox.Text;
            string haslo = HasloTextBox.Text;
            string imie = CapitalizeFirstLetter(ImieTextBox.Text);
            string nazwisko = CapitalizeFirstLetter(NazwiskoTextBox.Text);
            string plec = PlecComboBox.SelectedItem.ToString().Substring(0, 1); // 'K' or 'M'
            DateTime dataUrodzenia = DataUrodzeniaDateTimePicker.Value;
            string apteka = AptekaComboBox.SelectedItem?.ToString();

            // Walidacja danych wejściowych
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(haslo) || string.IsNullOrWhiteSpace(imie) ||
                string.IsNullOrWhiteSpace(nazwisko) || string.IsNullOrWhiteSpace(plec) || string.IsNullOrWhiteSpace(apteka))
            {
                MessageBox.Show("Wszystkie pola są wymagane!");
                return;
            }

            if (!IsValidLogin(login))
            {
                MessageBox.Show("Ten login jest już zajęty. Proszę wybrać inny.");
                return;
            }

            if (!IsValidPassword(haslo))
            {
                MessageBox.Show("Hasło musi mieć co najmniej 8 znaków, zawierać co najmniej jedną małą literę, jedną dużą literę, jedną cyfrę i jeden znak specjalny.");
                return;
            }

            bool success = await AddFarmaceutaAsync(login, haslo, imie, nazwisko, plec, dataUrodzenia, apteka, errorMessage =>
            {
                MessageBox.Show("Wystąpił błąd: " + errorMessage);
            });

            if (success)
            {
                MessageBox.Show("Użytkownik dodany pomyślnie!");
                parentFormRegister.InvokeReturnButtonClick();
            }
        }

        private bool IsValidLogin(string login)
        {
            using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
            {
                using (OracleCommand command = new OracleCommand("SELECT COUNT(*) FROM Uzytkownicy WHERE Login = :login", connection))
                {
                    command.Parameters.Add(new OracleParameter("login", login));
                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count == 0;
                }
            }
        }

        private bool IsValidPassword(string password)
        {
            if (password.Length < 8)
                return false;

            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasLowerCase = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecialChar = password.Any(ch => !char.IsLetterOrDigit(ch));

            return hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar;
        }

        private string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }

        private async Task<bool> AddFarmaceutaAsync(string login, string haslo, string imie, string nazwisko, string plec, DateTime dataUrodzenia, string apteka, Action<string> errorCallback)
        {
            try
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(haslo);
                using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
                {
                    using (OracleCommand command = new OracleCommand("user_pkg.AddFarmaceuta", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("p_login", OracleDbType.Varchar2).Value = login;
                        command.Parameters.Add("p_haslo", OracleDbType.Varchar2).Value = hashedPassword;
                        command.Parameters.Add("p_imie", OracleDbType.Varchar2).Value = imie;
                        command.Parameters.Add("p_nazwisko", OracleDbType.Varchar2).Value = nazwisko;
                        command.Parameters.Add("p_plec", OracleDbType.Char).Value = plec;
                        command.Parameters.Add("p_data_urodzenia", OracleDbType.Date).Value = dataUrodzenia;
                        command.Parameters.Add("p_apteka", OracleDbType.Varchar2).Value = apteka;

                        OracleParameter p_error_message = new OracleParameter("p_error_message", OracleDbType.Varchar2, 4000);
                        p_error_message.Direction = ParameterDirection.Output;
                        command.Parameters.Add(p_error_message);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        string errorMessage = p_error_message.Value.ToString();
                        if (errorMessage != "User added successfully.")
                        {
                            errorCallback(errorMessage);
                            return false;
                        }

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                errorCallback(ex.Message);
                return false;
            }
        }

        private void FillComboBoxes()
        {
            using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
            {
                connection.Open();

                // Wypełnianie AptekaComboBox
                using (OracleCommand command = new OracleCommand("SELECT Nazwa_apteki, Ulica, Numer, (SELECT Nazwa_miasta FROM Miasta WHERE Miasta.ID_Miasta = Apteki.ID_Miasta) AS Miasto FROM Apteki ORDER BY Nazwa_apteki", connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string aptekaInfo = $"{reader["Nazwa_apteki"]}, {reader["Miasto"]}, {reader["Ulica"]}, {reader["Numer"]}";
                            AptekaComboBox.Items.Add(aptekaInfo);
                        }
                    }
                }
            }
        }
    }
}
