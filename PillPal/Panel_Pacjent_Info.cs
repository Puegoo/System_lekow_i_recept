using System;
using System.Windows.Forms;

namespace PillPal
{
    public partial class Panel_Pacjent_Info : UserControl
    {
        private User loggedInUser;

        public Panel_Pacjent_Info(User user)
        {
            InitializeComponent();
            this.loggedInUser = user;

            LoadUserData();
        }

        private void LoadUserData()
        {
            lblImie.Text = loggedInUser.Imie;
            lblNazwisko.Text = loggedInUser.Nazwisko;
            lblPesel.Text = loggedInUser.Pesel;
            lblDataUrodz.Text = loggedInUser.DataUrodzenia.ToString("dd-MM-yyyy");
            lblPlec.Text = loggedInUser.Plec == "K" ? "Kobieta" : "Mężczyzna";
        }

        public void ReloadUserData(User user)
        {
            this.loggedInUser = user;
            LoadUserData();
        }
    }
}