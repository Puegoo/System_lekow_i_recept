using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace PillPal
{
    public partial class Panel_Pacjent_Edytuj : UserControl
    {
        private Pacjent loggedInPacjent;
        private User loggedInUser;
        public event EventHandler<User> UserUpdated;

        public Panel_Pacjent_Edytuj(Pacjent pacjent, User user)
        {
            InitializeComponent();
            this.loggedInPacjent = pacjent;
            this.loggedInUser = user;

            ElblImie.Text = loggedInPacjent.Imie;
            ElblNazwisko.Text = loggedInPacjent.Nazwisko;
            ElblPesel.Text = loggedInPacjent.Pesel;
            ElblPesel.ReadOnly = true; // Ustawienie pola PESEL jako nieedytowalnego
            EDataTime.Value = loggedInPacjent.DataUrodzenia;
            EComboPlec.Items.Add("Kobieta");
            EComboPlec.Items.Add("Mężczyzna");
            EComboPlec.SelectedIndex = loggedInPacjent.Plec == "K" ? 0 : 1;
        }

        private async void buttonZapiszZmiany_Click(object sender, EventArgs e)
        {
            string imie = ElblImie.Text;
            string nazwisko = ElblNazwisko.Text;
            DateTime dataUrodzenia = EDataTime.Value;
            string plec = EComboPlec.SelectedItem.ToString().Substring(0, 1); // 'K' lub 'M'

            if (string.IsNullOrWhiteSpace(imie) || string.IsNullOrWhiteSpace(nazwisko))
            {
                MessageBox.Show("Wszystkie pola są wymagane.");
                return;
            }

            string resultMessage = await UpdatePacjentAsync(loggedInPacjent.Id, imie, nazwisko, dataUrodzenia, plec);

            if (resultMessage == "Dane zostały pomyślnie zaktualizowane.")
            {
                MessageBox.Show(resultMessage);

                // Aktualizacja danych użytkownika
                loggedInPacjent.Imie = imie;
                loggedInPacjent.Nazwisko = nazwisko;
                loggedInPacjent.DataUrodzenia = dataUrodzenia;
                loggedInPacjent.Plec = plec;

                // Wywołanie zdarzenia UserUpdated
                UserUpdated?.Invoke(this, loggedInPacjent);
            }
            else
            {
                MessageBox.Show($"Wystąpił błąd podczas aktualizacji danych: {resultMessage}");
            }
        }

        private async Task<string> UpdatePacjentAsync(int idUzytkownika, string imie, string nazwisko, DateTime dataUrodzenia, string plec)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
                {
                    using (OracleCommand command = new OracleCommand("UPDATE_PACJENT", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("p_id_uzytkownika", OracleDbType.Int32).Value = idUzytkownika;
                        command.Parameters.Add("p_imie", OracleDbType.Varchar2).Value = imie;
                        command.Parameters.Add("p_nazwisko", OracleDbType.Varchar2).Value = nazwisko;
                        command.Parameters.Add("p_data_urodzenia", OracleDbType.Date).Value = dataUrodzenia;
                        command.Parameters.Add("p_plec", OracleDbType.Char).Value = plec;

                        OracleParameter p_error_message = new OracleParameter("p_error_message", OracleDbType.Varchar2, 4000);
                        p_error_message.Direction = ParameterDirection.Output;
                        command.Parameters.Add(p_error_message);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        return p_error_message.Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Wystąpił błąd: {ex.Message}";
            }
        }
    }
}
