using System;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace PillPal
{
    public partial class Panel_Farmaceuta_Recepty : UserControl
    {
        private Farmaceuta loggedInFarmaceuta;

        public Panel_Farmaceuta_Recepty(Farmaceuta farmaceuta)
        {
            InitializeComponent();
            this.loggedInFarmaceuta = farmaceuta;
            textBoxKodRecepty.MaxLength = 6; // Ustaw maksymalną długość na 6
            textBoxKodRecepty.KeyPress += TextBoxKodRecepty_KeyPress;
        }

        private void TextBoxKodRecepty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Zablokuj znaki inne niż cyfry
            }
        }

        private async void buttonSzukaj_Click(object sender, EventArgs e)
        {
            string kodRecepty = textBoxKodRecepty.Text;
            if (kodRecepty.Length != 6)
            {
                MessageBox.Show("Proszę wprowadzić prawidłowy 6-cyfrowy kod recepty.");
                return;
            }

            try
            {
                DataTable receptaData = await GetReceptaByKodAsync(kodRecepty);
                if (receptaData.Rows.Count > 0)
                {
                    dataGridViewRecepty.DataSource = receptaData;
                }
                else
                {
                    MessageBox.Show("Nie znaleziono recepty o podanym kodzie.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas wyszukiwania recepty: {ex.Message}");
            }
        }

        private async Task<DataTable> GetReceptaByKodAsync(string kodRecepty)
        {
            using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
            {
                using (OracleCommand command = new OracleCommand("SELECT * FROM Recepty WHERE Kod_Recepty = :kodRecepty", connection))
                {
                    command.Parameters.Add(new OracleParameter("kodRecepty", kodRecepty));
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
                int selectedReceptaId = Convert.ToInt32(dataGridViewRecepty.Rows[e.RowIndex].Cells["ID_RECEPTY"].Value);
                Win_Szczegoly_Recepty_Farmaceuta szczegolyReceptyForm = new Win_Szczegoly_Recepty_Farmaceuta(selectedReceptaId, loggedInFarmaceuta.IdApteki);
                szczegolyReceptyForm.ShowDialog();
            }
        }

        private void buttonSzczegoly_Click(object sender, EventArgs e)
        {
            if (dataGridViewRecepty.SelectedRows.Count > 0)
            {
                int selectedReceptaId = Convert.ToInt32(dataGridViewRecepty.SelectedRows[0].Cells["ID_RECEPTY"].Value);
                Win_Szczegoly_Recepty_Farmaceuta szczegolyReceptyForm = new Win_Szczegoly_Recepty_Farmaceuta(selectedReceptaId, loggedInFarmaceuta.IdApteki);
                szczegolyReceptyForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Proszę wybrać receptę z listy.");
            }
        }
    }
}
