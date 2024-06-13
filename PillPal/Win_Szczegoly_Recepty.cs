using System;
using System.Data;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;

namespace PillPal
{
    public partial class Win_Szczegoly_Recepty : Form
    {
        private int receptaId;

        public Win_Szczegoly_Recepty(int receptaId)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.receptaId = receptaId;
            LoadReceptaDetails();

            listViewLeki.Columns.Add("Nazwa leku", 400);
            listViewLeki.Columns.Add("Ilość sztuk", 160);
        }

        private async void LoadReceptaDetails()
        {
            try
            {
                DataTable receptaData = await GetReceptaDetailsAsync(receptaId);
                if (receptaData.Rows.Count > 0)
                {
                    DataRow row = receptaData.Rows[0];
                    textBoxKodRecepty.Text = row["Kod_Recepty"].ToString();
                    textBoxDataWystawienia.Text = Convert.ToDateTime(row["Data_Wystawienia"]).ToString("dd-MM-yyyy");
                    textBoxStatus.Text = row["Status"].ToString();
                    await LoadLeki(receptaId);
                }
                else
                {
                    MessageBox.Show("Nie znaleziono szczegółów dla wybranej recepty.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas ładowania szczegółów recepty: {ex.Message}");
            }
        }

        private async Task<DataTable> GetReceptaDetailsAsync(int receptaId)
        {
            using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
            {
                using (OracleCommand command = new OracleCommand("SELECT * FROM Recepty WHERE ID_Recepty = :receptaId", connection))
                {
                    command.Parameters.Add(new OracleParameter("receptaId", receptaId));
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

        private async Task LoadLeki(int receptaId)
        {
            try
            {
                List<Lek> leki = await GetLekiByReceptaIdAsync(receptaId);
                listViewLeki.Items.Clear();
                foreach (Lek lek in leki)
                {
                    ListViewItem item = new ListViewItem(lek.NazwaLeku);
                    item.SubItems.Add(lek.IloscSztuk.ToString());
                    listViewLeki.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas ładowania leków: {ex.Message}");
            }
        }

        private async Task<List<Lek>> GetLekiByReceptaIdAsync(int receptaId)
        {
            List<Lek> leki = new List<Lek>();
            using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
            {
                using (OracleCommand command = new OracleCommand(@"
                    SELECT L.Nazwa_Leku, RL.Ilosc_Sztuk 
                    FROM Recepty_Leki RL 
                    JOIN Leki L ON RL.ID_Leku = L.ID_Leku 
                    WHERE RL.ID_Recepty = :receptaId", connection))
                {
                    command.Parameters.Add(new OracleParameter("receptaId", receptaId));

                    await connection.OpenAsync();
                    using (OracleDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Lek lek = new Lek
                            {
                                NazwaLeku = reader["Nazwa_Leku"].ToString(),
                                IloscSztuk = Convert.ToInt32(reader["Ilosc_Sztuk"])
                            };
                            leki.Add(lek);
                        }
                    }
                }
            }
            return leki;
        }

        private void buttonZamknij_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
