using System;
using System.Windows.Forms;

namespace PillPal
{
    public partial class Win_Panel_Lekarz : Form
    {
        private Lekarz loggedInLekarz;
        private Loading_Win loadingWin;

        public Win_Panel_Lekarz(Lekarz lekarz, Loading_Win loadingWin)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.loggedInLekarz = lekarz;
            this.loadingWin = loadingWin;

            // Wyświetlanie domyślnego UserControl
            ShowUserControl(new Panel_Lekarz_Info(loggedInLekarz));
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

        private void Win_Panel_Lekarz_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Wylogowano pomyślnie!");
            loadingWin.Show();
        }

        private void Btn_Panel_info_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Panel_Lekarz_Info(loggedInLekarz));
        }
        private void Btn_Panel_Recepty_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Panel_Lekarz_Recepty(loggedInLekarz));
        }
    }
}
