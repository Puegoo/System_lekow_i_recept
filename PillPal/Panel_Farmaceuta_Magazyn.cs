using System;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace PillPal
{
    public partial class Panel_Farmaceuta_Magazyn : UserControl
    {
        private int aptekaId;

        public Panel_Farmaceuta_Magazyn(int aptekaId)
        {
            InitializeComponent();
            this.aptekaId = aptekaId;
            LoadMagazyn();
            LoadAptekaInfo();
        }

        private async void LoadMagazyn()
        {
            try
            {
                DataTable magazynData = await GetMagazynByAptekaIdAsync(aptekaId);
                dataGridViewMagazyn.DataSource = magazynData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas ładowania asortymentu: {ex.Message}");
            }
        }

        private async Task<DataTable> GetMagazynByAptekaIdAsync(int aptekaId)
        {
            using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
            {
                using (OracleCommand command = new OracleCommand(@"
                    SELECT A.ID_ASORTYMENTU, L.NAZWA_LEKU, A.ILOSC_DOSTEPNYCH_SZTUK, A.CENA
                    FROM ASORTYMENT A
                    JOIN LEKI L ON A.ID_LEKU = L.ID_LEKU
                    WHERE A.ID_APTEKI = :aptekaId", connection))
                {
                    command.Parameters.Add(new OracleParameter("aptekaId", aptekaId));
                    DataTable dataTable = new DataTable();

                    await connection.OpenAsync();
                    using (OracleDataReader reader = await command.ExecuteReaderAsync())
                    {
                        dataTable.Load(reader);
                    }
                    return dataTable;
                }
            }
        }

        private async void LoadAptekaInfo()
        {
            try
            {
                string nazwaApteki = await GetAptekaNameByIdAsync(aptekaId);
                labelInfo.Text = $"Apteka: {nazwaApteki}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas ładowania informacji o aptece: {ex.Message}");
            }
        }

        private async Task<string> GetAptekaNameByIdAsync(int aptekaId)
        {
            using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
            {
                using (OracleCommand command = new OracleCommand("SELECT NAZWA_APTEKI FROM APTEKI WHERE ID_APTEKI = :aptekaId", connection))
                {
                    command.Parameters.Add(new OracleParameter("aptekaId", aptekaId));

                    await connection.OpenAsync();
                    using (OracleDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            return reader.GetString(0);
                        }
                        else
                        {
                            throw new Exception("Nie znaleziono apteki o podanym ID.");
                        }
                    }
                }
            }
        }

        private void ButtonOdswiez_Click(object sender, EventArgs e)
        {
            LoadMagazyn();
        }
    }
}
