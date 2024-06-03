using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace PillPal
{
    public partial class Panel_Pacjent_Edytuj : UserControl
    {
        private User loggedInUser;
        public event EventHandler<User> UserUpdated;

        public Panel_Pacjent_Edytuj(User user)
        {
            InitializeComponent();
            this.loggedInUser = user;

            // Inicjalizacja pól formularza
            ElblImie.Text = loggedInUser.Imie;
            ElblNazwisko.Text = loggedInUser.Nazwisko;
            ElblPesel.Text = loggedInUser.Pesel;
            EDataTime.Value = loggedInUser.DataUrodzenia;
            EComboPlec.Items.Add("Kobieta");
            EComboPlec.Items.Add("Mężczyzna");
            EComboPlec.SelectedIndex = loggedInUser.Plec == "K" ? 0 : 1;
        }

        private async void buttonZapiszZmiany_Click(object sender, EventArgs e)
        {
            string imie = ElblImie.Text;
            string nazwisko = ElblNazwisko.Text;
            string pesel = ElblPesel.Text;
            DateTime dataUrodzenia = EDataTime.Value;
            string plec = EComboPlec.SelectedItem.ToString().Substring(0, 1); // 'K' or 'M'

            if (string.IsNullOrWhiteSpace(imie) || string.IsNullOrWhiteSpace(nazwisko) || string.IsNullOrWhiteSpace(pesel))
            {
                MessageBox.Show("Wszystkie pola są wymagane.");
                return;
            }

            if (pesel.Length != 11 || !pesel.All(char.IsDigit))
            {
                MessageBox.Show("PESEL musi mieć 11 cyfr.");
                return;
            }

            bool peselExists = await CheckPeselExists(pesel, loggedInUser.Id);
            if (peselExists)
            {
                MessageBox.Show("Podany PESEL jest już zajęty.");
                return;
            }

            bool success = await UpdatePacjentAsync(loggedInUser.Id, imie, nazwisko, pesel, dataUrodzenia, plec);

            if (success)
            {
                MessageBox.Show("Dane zostały pomyślnie zaktualizowane.");

                // Aktualizacja danych użytkownika
                loggedInUser.Imie = imie;
                loggedInUser.Nazwisko = nazwisko;
                loggedInUser.Pesel = pesel;
                loggedInUser.DataUrodzenia = dataUrodzenia;
                loggedInUser.Plec = plec;

                // Wywołanie zdarzenia UserUpdated
                UserUpdated?.Invoke(this, loggedInUser);
            }
            else
            {
                MessageBox.Show("Wystąpił błąd podczas aktualizacji danych.");
            }
        }

        private async Task<bool> UpdatePacjentAsync(int userId, string imie, string nazwisko, string pesel, DateTime dataUrodzenia, string plec)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
                {
                    using (OracleCommand command = new OracleCommand("UPDATE Pacjenci SET IMIE = :imie, NAZWISKO = :nazwisko, PESEL = :pesel, DATA_URODZENIA = :dataUrodzenia, PLEC = :plec WHERE ID_UZYTKOWNIKA = :id", connection))
                    {
                        command.Parameters.Add(new OracleParameter("imie", imie));
                        command.Parameters.Add(new OracleParameter("nazwisko", nazwisko));
                        command.Parameters.Add(new OracleParameter("pesel", pesel));
                        command.Parameters.Add(new OracleParameter("dataUrodzenia", dataUrodzenia));
                        command.Parameters.Add(new OracleParameter("plec", plec));
                        command.Parameters.Add(new OracleParameter("id", userId));

                        await connection.OpenAsync();
                        int rowsAffected = await command.ExecuteNonQueryAsync();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}");
                return false;
            }
        }

        private async Task<bool> CheckPeselExists(string pesel, int userId)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
                {
                    using (OracleCommand command = new OracleCommand("SELECT COUNT(*) FROM Pacjenci WHERE PESEL = :pesel AND ID_UZYTKOWNIKA != :userId", connection))
                    {
                        command.Parameters.Add(new OracleParameter("pesel", pesel));
                        command.Parameters.Add(new OracleParameter("userId", userId));

                        await connection.OpenAsync();
                        int count = Convert.ToInt32(await command.ExecuteScalarAsync());

                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas sprawdzania PESEL: {ex.Message}");
                return false;
            }
        }
    }
}
