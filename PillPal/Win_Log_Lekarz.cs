using System;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using BCrypt.Net;
using System.Linq;

namespace PillPal
{
    public partial class Win_Log_Lekarz : Form
    {
        private Loading_Win loadingWin;

        public Win_Log_Lekarz(Loading_Win loadingWin)
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
                Lekarz authenticatedLekarz = await AuthenticateLekarzAsync(login, haslo);
                if (authenticatedLekarz != null)
                {
                    // Pomyślne logowanie, otwórz nowe okno
                    Win_Panel_Lekarz panelLekarz = new Win_Panel_Lekarz(authenticatedLekarz, loadingWin);
                    panelLekarz.Show();

                    this.Close();
                    // Ukryj wszystkie inne okna
                    foreach (Form openForm in Application.OpenForms.Cast<Form>().ToList())
                    {
                        if (openForm != panelLekarz)
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


        private async Task<Lekarz> AuthenticateLekarzAsync(string login, string haslo)
        {
            using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
            {
                using (OracleCommand command = new OracleCommand("SELECT U.ID, U.LOGIN, U.HASLO, U.UPRAWNIENIA, L.ID, L.IMIE, L.NAZWISKO, L.NUMER_PWZ, L.DATA_URODZENIA, L.PLEC, S.NAZWA_SPECJALIZACJI, M.NAZWA_MIASTA " +
                                                                 "FROM UZYTKOWNICY U " +
                                                                 "JOIN LEKARZE L ON U.ID = L.ID_UZYTKOWNIKA " +
                                                                 "LEFT JOIN SPECJALIZACJE S ON L.ID_SPECJALIZACJI = S.ID_SPECJALIZACJI " +
                                                                 "LEFT JOIN MIASTA M ON L.ID_MIASTA = M.ID_MIASTA " +
                                                                 "WHERE UPPER(U.LOGIN) = UPPER(:login)", connection))
                {
                    command.Parameters.Add(new OracleParameter("login", login));

                    await connection.OpenAsync();
                    using (OracleDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            int userId = reader.GetInt32(0);
                            string storedHaslo = reader.GetString(2);
                            string uprawnienia = reader.GetString(3);

                            if (BCrypt.Net.BCrypt.Verify(haslo, storedHaslo))
                            {
                                if (uprawnienia == "Lekarz")
                                {
                                    return new Lekarz
                                    {
                                        Id = reader.GetInt32(4),
                                        Login = login,
                                        Imie = reader.GetString(5),
                                        Nazwisko = reader.GetString(6),
                                        PWZ = reader.GetString(7),
                                        DataUrodzenia = reader.GetDateTime(8),
                                        Plec = reader.GetString(9),
                                        Specjalizacja = reader.IsDBNull(10) ? null : reader.GetString(10),
                                        Miasto = reader.IsDBNull(11) ? null : reader.GetString(11)
                                    };
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
