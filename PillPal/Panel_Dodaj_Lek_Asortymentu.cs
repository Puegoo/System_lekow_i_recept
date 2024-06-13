using System;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace PillPal
{
    public partial class Panel_Dodaj_Lek_Asortymentu : UserControl
    {
        private int aptekaId;

        public Panel_Dodaj_Lek_Asortymentu(int aptekaId)
        {
            InitializeComponent();
            this.aptekaId = aptekaId;

            LoadLeki();
        }

        private async void LoadLeki()
        {
            using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
            {
                using (OracleCommand command = new OracleCommand("SELECT ID_LEKU, NAZWA_LEKU FROM LEKI", connection))
                {
                    await connection.OpenAsync();
                    using (OracleDataReader reader = await command.ExecuteReaderAsync())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        comboBoxLeki.DataSource = dataTable;
                        comboBoxLeki.DisplayMember = "NAZWA_LEKU";
                        comboBoxLeki.ValueMember = "ID_LEKU";
                    }
                }
            }
        }

        private void TextBoxIlosc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Zablokuj znaki inne niż cyfry
            }
        }

        private void TextBoxCena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Zablokuj znaki inne niż cyfry i kropkę
            }

            // Jeśli użytkownik wpisał kropkę, sprawdź czy jest już jedna kropka w polu tekstowym
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true; // Zablokuj drugą kropkę
            }
        }

        private async void buttonDodajLek_Click(object sender, EventArgs e)
        {
            if (comboBoxLeki.SelectedValue == null || string.IsNullOrWhiteSpace(textBoxIlosc.Text) || string.IsNullOrWhiteSpace(textBoxCena.Text))
            {
                MessageBox.Show("Proszę uzupełnić wszystkie pola.");
                return;
            }

            if (!int.TryParse(textBoxIlosc.Text, out int iloscSztuk))
            {
                MessageBox.Show("Proszę podać prawidłową ilość sztuk.");
                return;
            }

            if (!decimal.TryParse(textBoxCena.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal cena))
            {
                MessageBox.Show("Proszę podać prawidłową cenę.");
                return;
            }

            int idLeku = Convert.ToInt32(comboBoxLeki.SelectedValue);

            try
            {
                await AddLekToAsortymentAsync(aptekaId, idLeku, iloscSztuk, cena);
                MessageBox.Show("Lek został pomyślnie dodany do asortymentu.");
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas dodawania leku: {ex.Message}");
            }
        }

        private async Task AddLekToAsortymentAsync(int aptekaId, int idLeku, int iloscSztuk, decimal cena)
        {
            using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
            {
                using (OracleCommand command = new OracleCommand("ASORTYMENT_PKG.ADD_LEK_TO_ASORTYMENT", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("p_id_apteki", OracleDbType.Int32).Value = aptekaId;
                    command.Parameters.Add("p_id_leku", OracleDbType.Int32).Value = idLeku;
                    command.Parameters.Add("p_ilosc_sztuk", OracleDbType.Int32).Value = iloscSztuk;
                    command.Parameters.Add("p_cena", OracleDbType.Decimal).Value = cena;

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            comboBoxLeki.SelectedIndex = -1;
            textBoxIlosc.Clear();
            textBoxCena.Clear();
        }
    }
}
