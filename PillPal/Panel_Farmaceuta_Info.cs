using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace PillPal
{
    public partial class Panel_Farmaceuta_Info : UserControl
    {
        private Farmaceuta loggedInFarmaceuta;

        public Panel_Farmaceuta_Info(Farmaceuta farmaceuta)
        {
            InitializeComponent();
            this.loggedInFarmaceuta = farmaceuta;
            LoadFarmaceutaInfo();
        }

        private void LoadFarmaceutaInfo()
        {
            lblImie.Text = loggedInFarmaceuta.Imie;
            lblNazwisko.Text = loggedInFarmaceuta.Nazwisko;
            lblApteka.Text = GetAptekaName(loggedInFarmaceuta.IdApteki); // Funkcja do pobrania nazwy apteki
            lblDataUrodz.Text = loggedInFarmaceuta.DataUrodzenia.ToString("dd-MM-yyyy");
            lblPlec.Text = loggedInFarmaceuta.Plec == "K" ? "Kobieta" : "Mężczyzna";
        }

        private string GetAptekaName(int aptekaId)
        {
            // Logika do pobrania nazwy apteki z bazy danych na podstawie IdApteki
            // Poniżej przykład implementacji
            using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
            {
                using (OracleCommand command = new OracleCommand("SELECT Nazwa_Apteki FROM Apteki WHERE ID_Apteki = :aptekaId", connection))
                {
                    command.Parameters.Add(new OracleParameter("aptekaId", aptekaId));
                    connection.Open();
                    var result = command.ExecuteScalar();
                    return result != null ? result.ToString() : "Nieznana";
                }
            }
        }
    }
}
