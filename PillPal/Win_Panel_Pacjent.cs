using System;
using System.Windows.Forms;

namespace PillPal
{
    public partial class Win_Panel_Pacjent : Form
    {
        private Pacjent loggedInPacjent;
        private User loggedInUser;
        private Loading_Win loadingWin;

        public Win_Panel_Pacjent(Pacjent pacjent, User user, Loading_Win loadingWin)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.loggedInPacjent = pacjent;
            this.loggedInUser = user;
            this.loadingWin = loadingWin;

            // Wyświetlanie domyślnego UserControl
            ShowUserControl(new Panel_Pacjent_Info(loggedInPacjent));
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
            ShowUserControl(new Panel_Pacjent_Info(loggedInPacjent));
        }

        private void Btn_Panel_Lekarze_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Panel_Pacjent_Lekarze(loggedInPacjent));
        }

        private void Btn_Panel_Recepty_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Panel_Pacjent_Recepty(loggedInPacjent));
        }

        private void Btn_Panel_Edytuj_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Panel_Pacjent_Edytuj(loggedInPacjent, loggedInUser));
        }
    }
}
