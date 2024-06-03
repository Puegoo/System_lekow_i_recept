using System;
using System.Data;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms.VisualStyles;

namespace PillPal
{
    public partial class Win_Szczegoly_Recepty_Farmaceuta : Form
    {
        private int receptaId;
        private int aptekaId;

        public Win_Szczegoly_Recepty_Farmaceuta(int receptaId, int aptekaId)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.receptaId = receptaId;
            this.aptekaId = aptekaId;
            InitializeListView();
            LoadReceptaDetails();
        }

        private void InitializeListView()
        {
            listViewLeki.Columns.Add("Nazwa leku", 150);
            listViewLeki.Columns.Add("Ilość sztuk (przepisana)", 150);
            listViewLeki.Columns.Add("Dostępność", 100);
            listViewLeki.Columns.Add("Stan w magazynie", 150);
            listViewLeki.View = View.Details;
            listViewLeki.FullRowSelect = true;
        }

        private async void LoadReceptaDetails()
        {
            try
            {
                DataTable receptaData = await GetReceptaDetailsAsync(receptaId);
                if (receptaData.Rows.Count > 0)
                {
                    DataRow row = receptaData.Rows[0];
                    lblKodRecepty.Text = row["Kod_Recepty"].ToString();
                    lblDataWystawienia.Text = Convert.ToDateTime(row["Data_Wystawienia"]).ToString("dd-MM-yyyy");
                    lblStatus.Text = row["Status"].ToString();
                    await LoadLeki(receptaId, aptekaId);
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

        private async Task LoadLeki(int receptaId, int aptekaId)
        {
            try
            {
                DataTable lekiData = await GetLekiByReceptaIdAsync(receptaId, aptekaId);
                foreach (DataRow row in lekiData.Rows)
                {
                    ListViewItem item = new ListViewItem(row["Nazwa_Leku"].ToString());
                    item.SubItems.Add(row["Ilosc_Sztuk"].ToString());
                    item.SubItems.Add(row["Dostepnosc"].ToString());
                    item.SubItems.Add(row["Ilosc_dostepnych_sztuk"].ToString());
                    listViewLeki.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas ładowania leków: {ex.Message}");
            }
        }

        private async Task<DataTable> GetLekiByReceptaIdAsync(int receptaId, int aptekaId)
        {
            using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
            {
                using (OracleCommand command = new OracleCommand("GET_RECEPTA_LEKI_DETAILS", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("p_recepta_id", OracleDbType.Int32).Value = receptaId;
                    command.Parameters.Add("p_apteka_id", OracleDbType.Int32).Value = aptekaId;
                    command.Parameters.Add("cur", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

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

        private async void buttonUsunLek_Click(object sender, EventArgs e)
        {
            if (listViewLeki.SelectedItems.Count == 0)
            {
                MessageBox.Show("Proszę wybrać lek do usunięcia.");
                return;
            }

            if (listViewLeki.Items.Count == 1)
            {
                MessageBox.Show("Nie można usunąć ostatniego leku z recepty.");
                return;
            }

            var selectedItem = listViewLeki.SelectedItems[0];
            string lekNazwa = selectedItem.SubItems[0].Text;

            if (MessageBox.Show($"Czy na pewno chcesz usunąć lek: {lekNazwa}?", "Potwierdzenie", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    await UsunLekAsync(lekNazwa);
                    listViewLeki.Items.Remove(selectedItem);
                    MessageBox.Show("Lek został usunięty.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd podczas usuwania leku: {ex.Message}");
                }
            }
        }

        private async Task UsunLekAsync(string lekNazwa)
        {
            using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
            {
                using (OracleCommand command = new OracleCommand(@"
                    DELETE FROM Recepty_Leki 
                    WHERE ID_Recepty = :receptaId 
                    AND ID_Leku = (SELECT ID_Leku FROM Leki WHERE Nazwa_Leku = :lekNazwa)", connection))
                {
                    command.Parameters.Add(new OracleParameter("receptaId", receptaId));
                    command.Parameters.Add(new OracleParameter("lekNazwa", lekNazwa));

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        private async void buttonZatwierdz_Click(object sender, EventArgs e)
        {
            try
            {
                await ZatwierdzRecepteAsync();
                MessageBox.Show("Recepta została zrealizowana.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas zatwierdzania recepty: {ex.Message}");
            }
        }

        private async Task ZatwierdzRecepteAsync()
        {
            using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
            {
                using (OracleCommand command = new OracleCommand(@"
                    UPDATE Recepty 
                    SET Status = 'Zrealizowana', Data_wygasniecia = SYSDATE + 1 
                    WHERE ID_Recepty = :receptaId", connection))
                {
                    command.Parameters.Add(new OracleParameter("receptaId", receptaId));

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    // Odejmowanie ilości leków od stanu magazynowego
                    foreach (ListViewItem item in listViewLeki.Items)
                    {
                        string lekNazwa = item.SubItems[0].Text;
                        int iloscSztuk = int.Parse(item.SubItems[1].Text);

                        using (OracleCommand updateCommand = new OracleCommand(@"
                            UPDATE Asortyment 
                            SET Ilosc_dostepnych_sztuk = Ilosc_dostepnych_sztuk - :iloscSztuk 
                            WHERE ID_Leku = (SELECT ID_Leku FROM Leki WHERE Nazwa_Leku = :lekNazwa)
                            AND ID_Apteki = :aptekaId", connection))
                        {
                            updateCommand.Parameters.Add(new OracleParameter("iloscSztuk", iloscSztuk));
                            updateCommand.Parameters.Add(new OracleParameter("lekNazwa", lekNazwa));
                            updateCommand.Parameters.Add(new OracleParameter("aptekaId", aptekaId));

                            await updateCommand.ExecuteNonQueryAsync();
                        }
                    }
                }
            }
        }

        public void buttonZamknij_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
