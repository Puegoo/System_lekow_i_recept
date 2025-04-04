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
    public partial class Win_Log_Pacjent : Form
    {
        private Loading_Win loadingWin;

        public Win_Log_Pacjent(Loading_Win loadingWin)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.loadingWin = loadingWin;
        }

        private void Win_Log_Pacjent_Load(object sender, EventArgs e)
        {
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
                (Pacjent authenticatedPacjent, User authenticatedUser) = await AuthenticatePacjentAsync(login, haslo);
                if (authenticatedPacjent != null && authenticatedUser != null)
                {
                    // Pomyślne logowanie, otwórz nowe okno
                    Win_Panel_Pacjent panelPacjent = new Win_Panel_Pacjent(authenticatedPacjent, authenticatedUser, this.loadingWin);
                    panelPacjent.Show();

                    this.Close();
                    // Ukryj wszystkie inne okna
                    foreach (Form openForm in Application.OpenForms.Cast<Form>().ToList())
                    {
                        if (openForm != panelPacjent)
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

        private async Task<(Pacjent, User)> AuthenticatePacjentAsync(string login, string haslo)
        {
            using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
            {
                using (OracleCommand command = new OracleCommand("SELECT U.ID, U.LOGIN, U.HASLO, U.UPRAWNIENIA, P.ID, P.IMIE, P.NAZWISKO, P.PESEL, P.DATA_URODZENIA, P.PLEC " +
                                                                 "FROM UZYTKOWNICY U " +
                                                                 "JOIN PACJENCI P ON U.ID = P.ID_UZYTKOWNIKA " +
                                                                 "WHERE UPPER(U.LOGIN) = UPPER(:login)", connection))
                {
                    command.Parameters.Add(new OracleParameter("login", login));

                    await connection.OpenAsync();
                    using (OracleDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            string storedHaslo = reader.GetString(2);
                            string uprawnienia = reader.GetString(3);

                            if (BCrypt.Net.BCrypt.Verify(haslo, storedHaslo))
                            {
                                if (uprawnienia == "Pacjent")
                                {
                                    User authenticatedUser = new User
                                    {
                                        Id = reader.GetInt32(0),
                                        Login = login,
                                        Haslo = storedHaslo,
                                        Uprawnienia = uprawnienia,
                                        Imie = reader.GetString(5),
                                        Nazwisko = reader.GetString(6),
                                        Pesel = reader.GetString(7),
                                        DataUrodzenia = reader.GetDateTime(8),
                                        Plec = reader.GetString(9)
                                    };

                                    Pacjent authenticatedPacjent = new Pacjent
                                    {
                                        IdPacjenta = reader.GetInt32(4),
                                        Id = reader.GetInt32(0),
                                        Login = login,
                                        Imie = reader.GetString(5),
                                        Nazwisko = reader.GetString(6),
                                        Pesel = reader.GetString(7),
                                        DataUrodzenia = reader.GetDateTime(8),
                                        Plec = reader.GetString(9)
                                    };

                                    return (authenticatedPacjent, authenticatedUser);
                                }
                                else
                                {
                                    labelError.Text = "Proszę wybrać właściwy typ konta.";
                                    return (null, null);
                                }
                            }
                        }
                    }
                }
            }

            return (null, null); // Nieprawidłowy login lub hasło
        }
    }
}
