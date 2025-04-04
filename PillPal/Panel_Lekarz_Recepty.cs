using System;
using System.Data;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace PillPal
{
    public partial class Panel_Lekarz_Recepty : UserControl
    {
        private Lekarz loggedInLekarz;

        public Panel_Lekarz_Recepty(Lekarz lekarz)
        {
            InitializeComponent();
            this.loggedInLekarz = lekarz;
        }

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            string pesel = textBoxPesel.Text;
            if (string.IsNullOrWhiteSpace(pesel))
            {
                MessageBox.Show("Proszę wprowadzić numer PESEL.");
                return;
            }

            try
            {
                DataTable pacjentData = await SearchPacjentByPeselAsync(pesel);
                if (pacjentData.Rows.Count > 0)
                {
                    dataGridViewPacjenci.DataSource = pacjentData;
                }
                else
                {
                    MessageBox.Show("Nie znaleziono pacjenta o podanym numerze PESEL.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas wyszukiwania pacjenta: {ex.Message}");
            }
        }

        private async Task<DataTable> SearchPacjentByPeselAsync(string pesel)
        {
            using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
            {
                using (OracleCommand command = new OracleCommand("SELECT * FROM Pacjenci WHERE PESEL = :pesel", connection))
                {
                    command.Parameters.Add(new OracleParameter("pesel", pesel));
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

        private void AddReceptaButton_Click(object sender, EventArgs e)
        {
            if (dataGridViewPacjenci.SelectedRows.Count > 0)
            {
                int selectedPacjentId = Convert.ToInt32(dataGridViewPacjenci.SelectedRows[0].Cells["ID"].Value);
                Win_Dodaj_Recepte winDodajRecepte = new Win_Dodaj_Recepte(selectedPacjentId, loggedInLekarz.Id);
                winDodajRecepte.ShowDialog();
            }
            else
            {
                MessageBox.Show("Proszę wybrać pacjenta z listy.");
            }
        }
    }
}
