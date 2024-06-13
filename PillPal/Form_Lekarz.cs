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
    public partial class Form_Lekarz : UserControl
    {
        private DatabaseService databaseService;
        private AccountType_Form_Register parentFormRegister;

        public Form_Lekarz(AccountType_Form_Register parentFormRegister)
        {
            InitializeComponent();
            DataUrodzeniaDateTimePicker.MaxDate = DateTime.Now;

            Plec_LekarzComboBox.Items.Add("Kobieta");
            Plec_LekarzComboBox.Items.Add("Mężczyzna");
            Plec_LekarzComboBox.SelectedIndex = 0;

            databaseService = new DatabaseService();
            this.parentFormRegister = parentFormRegister;

            FillComboBoxes();
        }

        private void FillComboBoxes()
        {
            FillComboBox(SpecjalizacjaComboBox, "SELECT nazwa_specjalizacji FROM Specjalizacje ORDER BY nazwa_specjalizacji");
            FillComboBox(MiastoComboBox, "SELECT Nazwa_miasta FROM Miasta ORDER BY Nazwa_miasta");
        }

        private void FillComboBox(ComboBox comboBox, string query)
        {
            using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
            {
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    connection.Open();
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }

        private async void ZarejestrujButton_Click(object sender, EventArgs e)
        {
            string login = LoginTextBox.Text;
            string haslo = HasloTextBox.Text;
            string imie = CapitalizeFirstLetter(ImieTextBox.Text);
            string nazwisko = CapitalizeFirstLetter(NazwiskoTextBox.Text);
            string plec = Plec_LekarzComboBox.SelectedItem.ToString().Substring(0, 1); // 'K' or 'M'
            DateTime dataUrodzenia = DataUrodzeniaDateTimePicker.Value;
            string specjalizacja = SpecjalizacjaComboBox.SelectedItem.ToString();
            string numerPWZ = PWZTextBox.Text;
            string miasto = MiastoComboBox.SelectedItem.ToString();

            // Walidacja danych wejściowych
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(haslo) || string.IsNullOrWhiteSpace(imie) ||
                string.IsNullOrWhiteSpace(nazwisko) || string.IsNullOrWhiteSpace(specjalizacja) || string.IsNullOrWhiteSpace(numerPWZ) ||
                string.IsNullOrWhiteSpace(miasto) || string.IsNullOrWhiteSpace(plec))
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

            if (!IsValidNumerPWZ(numerPWZ))
            {
                MessageBox.Show("Numer PWZ musi zawierać dokładnie 7 cyfr.");
                return;
            }

            bool success = await AddLekarzAsync(login, haslo, imie, nazwisko, plec, dataUrodzenia, specjalizacja, numerPWZ, miasto, errorMessage =>
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

        private bool IsValidNumerPWZ(string numerPWZ)
        {
            return numerPWZ.Length == 7 && numerPWZ.All(char.IsDigit);
        }

        private string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }

        private async Task<bool> AddLekarzAsync(string login, string haslo, string imie, string nazwisko, string plec, DateTime dataUrodzenia, string specjalizacja, string numerPWZ, string miasto, Action<string> errorCallback)
        {
            try
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(haslo);
                using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
                {
                    using (OracleCommand command = new OracleCommand("user_pkg.AddLekarz", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("p_login", OracleDbType.Varchar2).Value = login;
                        command.Parameters.Add("p_haslo", OracleDbType.Varchar2).Value = hashedPassword;
                        command.Parameters.Add("p_imie", OracleDbType.Varchar2).Value = imie;
                        command.Parameters.Add("p_nazwisko", OracleDbType.Varchar2).Value = nazwisko;
                        command.Parameters.Add("p_plec", OracleDbType.Char).Value = plec;
                        command.Parameters.Add("p_data_urodzenia", OracleDbType.Date).Value = dataUrodzenia;
                        command.Parameters.Add("p_specjalizacja", OracleDbType.Varchar2).Value = specjalizacja;
                        command.Parameters.Add("p_numer_pwz", OracleDbType.Varchar2).Value = numerPWZ;
                        command.Parameters.Add("p_miasto", OracleDbType.Varchar2).Value = miasto;

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

        private void PWZTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sprawdź, czy klawisz to cyfra lub klawisz Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Zablokuj znak
            }

            // Sprawdź, czy długość tekstu po wprowadzeniu nowego znaku nie przekracza 7 cyfr
            if (char.IsDigit(e.KeyChar) && PWZTextBox.Text.Length >= 7)
            {
                e.Handled = true; // Zablokuj znak
            }
        }
    }
}
