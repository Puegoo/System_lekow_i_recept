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
    public partial class Win_Log_Farmaceuta : Form
    {
        private Loading_Win loadingWin;

        public Win_Log_Farmaceuta(Loading_Win loadingWin)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.loadingWin = loadingWin;
        }

        private async void Zalogujsie_Click(object sender, EventArgs e)
        {
            string login = LoginTextBox.Text;
            string haslo = HasloTextBox.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(haslo))
            {
                labelError.Text = "Login i hasło są wymagane.";
                return;
            }

            try
            {
                Farmaceuta authenticatedFarmaceuta = await AuthenticateFarmaceutaAsync(login, haslo);
                if (authenticatedFarmaceuta != null)
                {
                    // Pomyślne logowanie, otwórz nowe okno
                    Win_Panel_Farmaceuta panelFarmaceuta = new Win_Panel_Farmaceuta(authenticatedFarmaceuta, loadingWin);
                    panelFarmaceuta.Show();

                    this.Close();
                    // Ukryj wszystkie inne okna
                    foreach (Form openForm in Application.OpenForms.Cast<Form>().ToList())
                    {
                        if (openForm != panelFarmaceuta)
                        {
                            openForm.Hide();
                        }
                    }
                }
                else
                {
                    labelError.Text = "Nieprawidłowy login lub hasło, lub wybrano zły typ konta.";
                }
            }
            catch (Exception ex)
            {
                labelError.Text = $"Wystąpił błąd: {ex.Message}";
            }
        }

        private async Task<Farmaceuta> AuthenticateFarmaceutaAsync(string login, string haslo)
        {
            using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
            {
                using (OracleCommand command = new OracleCommand("SELECT ID, LOGIN, HASLO, UPRAWNIENIA FROM Uzytkownicy WHERE UPPER(LOGIN) = UPPER(:login)", connection))
                {
                    command.Parameters.Add(new OracleParameter("login", login));

                    await connection.OpenAsync();
                    using (OracleDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            int id = reader.GetInt32(0);
                            string storedHaslo = reader.GetString(2);
                            string uprawnienia = reader.GetString(3);

                            if (BCrypt.Net.BCrypt.Verify(haslo, storedHaslo))
                            {
                                if (uprawnienia == "Farmaceuta")
                                {
                                    // Tworzymy nowy obiekt Farmaceuta i ustawiamy jego właściwości
                                    Farmaceuta authenticatedFarmaceuta = new Farmaceuta
                                    {
                                        Id = id,
                                        Login = login,
                                        Uprawnienia = uprawnienia
                                    };

                                    // Pobieramy dodatkowe dane z tabeli Farmaceuci
                                    using (OracleCommand farmaceutaCommand = new OracleCommand("SELECT IMIE, NAZWISKO, ID_APTEKI, DATA_URODZENIA, PLEC FROM Farmaceuci WHERE ID_UZYTKOWNIKA = :id", connection))
                                    {
                                        farmaceutaCommand.Parameters.Add(new OracleParameter("id", authenticatedFarmaceuta.Id));

                                        using (OracleDataReader farmaceutaReader = await farmaceutaCommand.ExecuteReaderAsync())
                                        {
                                            if (await farmaceutaReader.ReadAsync())
                                            {
                                                authenticatedFarmaceuta.Imie = farmaceutaReader.GetString(0);
                                                authenticatedFarmaceuta.Nazwisko = farmaceutaReader.GetString(1);
                                                authenticatedFarmaceuta.IdApteki = farmaceutaReader.GetInt32(2);
                                                authenticatedFarmaceuta.DataUrodzenia = farmaceutaReader.GetDateTime(3);
                                                authenticatedFarmaceuta.Plec = farmaceutaReader.GetString(4);
                                            }
                                        }
                                    }

                                    return authenticatedFarmaceuta;
                                }
                                else
                                {
                                    labelError.Text = "Proszę wybrać właściwy typ konta.";
                                    return null;
                                }
                            }
                        }
                    }
                }
            }

            return null; // Nieprawidłowy login lub hasło
        }
    }
}
