using System;
using System.Windows.Forms;

namespace PillPal
{
    public partial class Panel_Lekarz_Info : UserControl
    {
        private Lekarz loggedInLekarz;

        public Panel_Lekarz_Info(Lekarz lekarz)
        {
            InitializeComponent();
            this.loggedInLekarz = lekarz;

            // Wypełnij pola danymi zalogowanego lekarza
            lblImie.Text = loggedInLekarz.Imie;
            lblNazwisko.Text = loggedInLekarz.Nazwisko;
            lblPWZ.Text = loggedInLekarz.PWZ;
            lblDataUrodz.Text = loggedInLekarz.DataUrodzenia.ToString("dd-MM-yyyy");
            lblPlec.Text = loggedInLekarz.Plec == "K" ? "Kobieta" : "Mężczyzna";
            lblSpecjalizacje.Text = loggedInLekarz.Specjalizacja;
            lblMiasto.Text = loggedInLekarz.Miasto;
        }
    }
}
