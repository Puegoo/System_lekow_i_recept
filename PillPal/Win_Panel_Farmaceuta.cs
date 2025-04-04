using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PillPal
{
    public partial class Win_Panel_Farmaceuta : Form
    {
        private Farmaceuta loggedInFarmaceuta;
        private Loading_Win loadingWin;

        public Win_Panel_Farmaceuta(Farmaceuta farmaceuta, Loading_Win loadingWin)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.loggedInFarmaceuta = farmaceuta;
            this.loadingWin = loadingWin;


            ShowUserControl(new Panel_Farmaceuta_Info(loggedInFarmaceuta));
        }

        private void ShowUserControl(UserControl userControl)
        {
            Main_Panel.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            Main_Panel.Controls.Add(userControl);
        }

        private void Wylogujsie_Click(object sender, EventArgs e)
        {
            this.Close();
            loadingWin.Show();
        }

        private void Win_Panel_Farmaceuta_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Wylogowano pomyślnie!");
            loadingWin.Show();
        }

        private void Btn_Panel_info_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Panel_Farmaceuta_Info(loggedInFarmaceuta));
        }

        private void Btn_Panel_Leki_Click(object sender, EventArgs e)
        {
           // ShowUserControl(new Panel_Farmaceuta_Leki(loggedInFarmaceuta));
        }

        private void Btn_Panel_Recepty_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Panel_Farmaceuta_Recepty(loggedInFarmaceuta));
        }

        private void Btn_Panel_Edytuj_Click(object sender, EventArgs e)
        {
            //ShowUserControl(new Panel_Farmaceuta_Edytuj(loggedInFarmaceuta));
        }

        private void Btn_Panel_Apteki_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Panel_Dodaj_Lek_Asortymentu(loggedInFarmaceuta.IdApteki));
        }

        private void Btn_Panel_Magazyn_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Panel_Farmaceuta_Magazyn(loggedInFarmaceuta.IdApteki));
        }
    }
}
