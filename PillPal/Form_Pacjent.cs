using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using BCrypt.Net;

namespace PillPal
{
    public partial class Form_Pacjent : UserControl
    {
        private DatabaseService databaseService;
        private AccountType_Form_Register parentFormRegister;

        public Form_Pacjent(AccountType_Form_Register parentFormRegister)
        {
            InitializeComponent();
            DataUrodzeniaDateTimePicker.MaxDate = DateTime.Now;
            PlecComboBox.Items.Add("Kobieta");
            PlecComboBox.Items.Add("Mężczyzna");
            PlecComboBox.SelectedIndex = 0;

            databaseService = new DatabaseService();
            this.parentFormRegister = parentFormRegister;
        }

        private async void ZarejestrujButton_Click(object sender, EventArgs e)
        {
            string login = LoginTextBox.Text;
            string haslo = HasloTextBox.Text;
            string imie = CapitalizeFirstLetter(ImieTextBox.Text);
            string nazwisko = CapitalizeFirstLetter(NazwiskoTextBox.Text);
            string pesel = PeselTextBox.Text;
            string plec = PlecComboBox.SelectedItem.ToString().Substring(0, 1); // 'K' or 'M'
            DateTime dataUrodzenia = DataUrodzeniaDateTimePicker.Value;

            // Walidacja danych wejściowych
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(haslo) || string.IsNullOrWhiteSpace(imie) ||
                string.IsNullOrWhiteSpace(nazwisko) || string.IsNullOrWhiteSpace(pesel) || string.IsNullOrWhiteSpace(plec))
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

            if (!IsValidPesel(pesel))
            {
                MessageBox.Show("PESEL musi zawierać tylko cyfry i mieć 11 znaków.");
                return;
            }

            if (await IsPeselExists(pesel))
            {
                MessageBox.Show("Ten PESEL już istnieje w bazie danych.");
                return;
            }

            bool success = await AddPacjentAsync(login, haslo, imie, nazwisko, pesel, plec, dataUrodzenia, errorMessage =>
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

        private bool IsValidPesel(string pesel)
        {
            return pesel.Length == 11 && pesel.All(char.IsDigit);
        }

        private async Task<bool> IsPeselExists(string pesel)
        {
            using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
            {
                using (OracleCommand command = new OracleCommand("SELECT PESEL_EXISTS(:pesel) FROM DUAL", connection))
                {
                    command.Parameters.Add(new OracleParameter("pesel", pesel));
                    connection.Open();
                    int count = Convert.ToInt32(await command.ExecuteScalarAsync());
                    return count > 0;
                }
            }
        }

        private string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }

        private async Task<bool> AddPacjentAsync(string login, string haslo, string imie, string nazwisko, string pesel, string plec, DateTime dataUrodzenia, Action<string> errorCallback)
        {
            try
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(haslo);
                using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
                {
                    using (OracleCommand command = new OracleCommand("user_pkg.AddPacjent", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("p_login", OracleDbType.Varchar2).Value = login;
                        command.Parameters.Add("p_haslo", OracleDbType.Varchar2).Value = hashedPassword;
                        command.Parameters.Add("p_imie", OracleDbType.Varchar2).Value = imie;
                        command.Parameters.Add("p_nazwisko", OracleDbType.Varchar2).Value = nazwisko;
                        command.Parameters.Add("p_pesel", OracleDbType.Varchar2).Value = pesel;
                        command.Parameters.Add("p_plec", OracleDbType.Char).Value = plec;
                        command.Parameters.Add("p_data_urodzenia", OracleDbType.Date).Value = dataUrodzenia;

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

        private void PeselTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void PlecComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
    }
}
