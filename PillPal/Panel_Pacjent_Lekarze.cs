using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace PillPal
{
    public partial class Panel_Pacjent_Lekarze : UserControl
    {
        private User loggedInUser;

        public Panel_Pacjent_Lekarze(User user)
        {
            InitializeComponent();
            loggedInUser = user;
            LoadLekarze();
            LoadFilterOptions();

            // Rozciągnięcie kolumn na całą szerokość DataGridView
            dataGridViewLekarze.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadLekarze(string miasto = null, string specjalizacja = null)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString;
            string procedureName = "USER_PKG.GET_LEKARZE";

            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand(procedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("p_miasto", OracleDbType.Varchar2).Value = string.IsNullOrEmpty(miasto) || miasto == "Wszystkie" ? (object)DBNull.Value : miasto;
                        command.Parameters.Add("p_specjalizacja", OracleDbType.Varchar2).Value = string.IsNullOrEmpty(specjalizacja) || specjalizacja == "Wszystkie" ? (object)DBNull.Value : specjalizacja;
                        command.Parameters.Add("cur", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                        OracleDataAdapter adapter = new OracleDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridViewLekarze.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas ładowania lekarzy: {ex.Message}");
            }
        }

        private void LoadFilterOptions()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString;

            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();

                    // Ładowanie miast do ComboBox
                    comboBoxMiasto.Items.Add("Wszystkie");
                    using (OracleCommand command = new OracleCommand("SELECT nazwa_miasta FROM MIASTA ORDER BY nazwa_miasta", connection))
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxMiasto.Items.Add(reader.GetString(0));
                        }
                    }
                    comboBoxMiasto.SelectedIndex = 0; // Ustawienie domyślnego wyboru na "Wszystkie"

                    // Ładowanie specjalizacji do ComboBox
                    comboBoxSpecjalizacja.Items.Add("Wszystkie");
                    using (OracleCommand command = new OracleCommand("SELECT nazwa_specjalizacji FROM SPECJALIZACJE ORDER BY nazwa_specjalizacji", connection))
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxSpecjalizacja.Items.Add(reader.GetString(0));
                        }
                    }
                    comboBoxSpecjalizacja.SelectedIndex = 0; // Ustawienie domyślnego wyboru na "Wszystkie"
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas ładowania opcji filtrowania: {ex.Message}");
            }
        }

        private void buttonFiltruj_Click(object sender, EventArgs e)
        {
            string selectedMiasto = comboBoxMiasto.SelectedItem?.ToString();
            string selectedSpecjalizacja = comboBoxSpecjalizacja.SelectedItem?.ToString();

            LoadLekarze(selectedMiasto, selectedSpecjalizacja);
        }
    }
}
