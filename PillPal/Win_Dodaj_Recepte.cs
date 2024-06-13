using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace PillPal
{
    public partial class Win_Dodaj_Recepte : Form
    {
        private int pacjentId;
        private int lekarzId;
        private List<ReceptaLek> receptaLeki;
        private string kodReceipty; 
        private int idReceipty;

        public Win_Dodaj_Recepte(int pacjentId, int lekarzId)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.pacjentId = pacjentId;
            this.lekarzId = lekarzId;
            this.receptaLeki = new List<ReceptaLek>();

            LoadLeki();

            lblInfoPacjent.Text = $"Pacjent ID: {pacjentId}, Lekarz ID: {lekarzId}";

            listViewLeki.Columns.Add("Nazwa leku", 400);
            listViewLeki.Columns.Add("Ilość sztuk", 160);
        }

        private void LoadLeki()
        {
            using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
            {
                using (OracleCommand command = new OracleCommand("SELECT ID_LEKU, NAZWA_LEKU FROM LEKI", connection))
                {
                    connection.Open();
                    using (OracleDataReader reader = command.ExecuteReader())
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

        private void buttonDodajLek_Click(object sender, EventArgs e)
        {
            int iloscSztuk;
            if (!int.TryParse(numericUpDownIlosc.Text, out iloscSztuk) || iloscSztuk <= 0)
            {
                MessageBox.Show("Proszę podać prawidłową ilość sztuk.");
                return;
            }

            int idLeku = Convert.ToInt32(comboBoxLeki.SelectedValue);
            string nazwaLeku = comboBoxLeki.Text;

            ReceptaLek nowyLek = new ReceptaLek { IdLeku = idLeku, NazwaLeku = nazwaLeku, IloscSztuk = iloscSztuk };
            receptaLeki.Add(nowyLek);

            ListViewItem item = new ListViewItem(nazwaLeku);
            item.SubItems.Add(iloscSztuk.ToString());
            listViewLeki.Items.Add(item);

            numericUpDownIlosc.Value = 1;
        }

        private async void buttonZatwierdzRecepte_Click(object sender, EventArgs e)
        {
            bool success = await AddReceptaAsync(pacjentId, lekarzId, DateTime.Now, receptaLeki);

            if (success)
            {
                MessageBox.Show("Recepta została pomyślnie dodana.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Wystąpił błąd podczas dodawania recepty.");
            }
        }

        private async Task<bool> AddReceptaAsync(int idPacjenta, int idLekarza, DateTime dataWystawienia, List<ReceptaLek> leki)
        {
            using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString))
            {
                if (string.IsNullOrEmpty(kodReceipty))
                {
                    using (OracleCommand command = new OracleCommand("recept_pkg.ADD_RECEIPTA", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("P_ID_PACJENTA", OracleDbType.Int32).Value = idPacjenta;
                        command.Parameters.Add("P_ID_LEKARZA", OracleDbType.Int32).Value = idLekarza;
                        command.Parameters.Add("P_DATA_WYSTAWIENIA", OracleDbType.Date).Value = dataWystawienia;

                        OracleParameter p_kod_receipty = new OracleParameter("P_KOD_RECEIPTY", OracleDbType.Varchar2, 50);
                        p_kod_receipty.Direction = ParameterDirection.Output;
                        command.Parameters.Add(p_kod_receipty);

                        OracleParameter p_id_receipty = new OracleParameter("P_ID_RECEIPTY", OracleDbType.Int32);
                        p_id_receipty.Direction = ParameterDirection.Output;
                        command.Parameters.Add(p_id_receipty);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        kodReceipty = p_kod_receipty.Value.ToString();
                        idReceipty = Convert.ToInt32(((OracleDecimal)p_id_receipty.Value).Value);
                    }
                }

                foreach (var lek in leki)
                {
                    using (OracleCommand lekCommand = new OracleCommand("recept_pkg.ADD_RECEIPTA_LEKI", connection))
                    {
                        lekCommand.CommandType = CommandType.StoredProcedure;

                        lekCommand.Parameters.Add("P_ID_RECEIPTY", OracleDbType.Int32).Value = idReceipty;
                        lekCommand.Parameters.Add("P_ID_LEKU", OracleDbType.Int32).Value = lek.IdLeku;
                        lekCommand.Parameters.Add("P_ILOSC_SZTUK", OracleDbType.Int32).Value = lek.IloscSztuk;

                        await lekCommand.ExecuteNonQueryAsync();
                    }
                }

                return true;
            }
        }

    }

    public class ReceptaLek
    {
        public int IdLeku { get; set; }
        public string NazwaLeku { get; set; }
        public int IloscSztuk { get; set; }
    }
}
