using System;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace PillPal
{
    public partial class Panel_Pacjent_Recepty : UserControl
    {
        private User loggedInUser;

        public Panel_Pacjent_Recepty(User user)
        {
            InitializeComponent();
            this.loggedInUser = user;
            LoadRecepty();
        }

        private void buttonOdswiez_Click(object sender, EventArgs e)
        {
            LoadRecepty();
        }

        private async void LoadRecepty()
        {
            try
            {
                DataTable receptyData = await GetReceptyByPacjentIdAsync(loggedInUser.Id);
                dataGridViewRecepty.DataSource = receptyData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas ładowania recept: {ex.Message}");
            }
        }

        private async Task<DataTable> GetReceptyByPacjentIdAsync(int pacjentId)
        {
            using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
            {
                using (OracleCommand command = new OracleCommand("SELECT * FROM Recepty WHERE ID_Pacjenta = :pacjentId", connection))
                {
                    command.Parameters.Add(new OracleParameter("pacjentId", pacjentId));
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

        private void dataGridViewRecepty_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int selectedReceptaId = Convert.ToInt32(dataGridViewRecepty.Rows[e.RowIndex].Cells["ID_Recepty"].Value);
                Win_Szczegoly_Recepty szczegolyReceptyForm = new Win_Szczegoly_Recepty(selectedReceptaId);
                szczegolyReceptyForm.ShowDialog();
            }
        }

        private void buttonSzczegoly_Click(object sender, EventArgs e)
        {
            if (dataGridViewRecepty.SelectedRows.Count > 0)
            {
                int selectedReceptaId = Convert.ToInt32(dataGridViewRecepty.SelectedRows[0].Cells["ID_Recepty"].Value);
                Win_Szczegoly_Recepty winSzczegolyRecepty = new Win_Szczegoly_Recepty(selectedReceptaId);
                winSzczegolyRecepty.ShowDialog();
            }
            else
            {
                MessageBox.Show("Proszę wybrać receptę z listy.");
            }
        }
    }
}
