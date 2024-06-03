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
    public partial class Win_Panel_Pacjent : Form
    {
        private User loggedInUser;
        private Loading_Win loadingWin;

        public Win_Panel_Pacjent(User user, Loading_Win loadingWin)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.loggedInUser = user;
            this.loadingWin = loadingWin;

            // Wyświetlanie domyślnego UserControl
            ShowUserControl(new Panel_Pacjent_Info(loggedInUser));
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

        private void Win_Panel_Pacjent_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Wylogowano pomyślnie!");
            loadingWin.Show();
        }

        private void Btn_Panel_info_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Panel_Pacjent_Info(loggedInUser));
        }

        private void Btn_Panel_Lekarze_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Panel_Pacjent_Lekarze(loggedInUser));
        }

        private void Btn_Panel_Recepty_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Panel_Pacjent_Recepty(loggedInUser));
        }

        private void Btn_Panel_Edytuj_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Panel_Pacjent_Edytuj(loggedInUser));
        }
    }
}
