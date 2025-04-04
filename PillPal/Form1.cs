using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PillPal
{
    public partial class Loading_Win : Form
    {
        public Loading_Win()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            this.Size = new Size(1245, 800);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private async void Identification_Win_Load(object sender, EventArgs e)
        {
            // Rozpocznij animację progressbaru przez 2 sekundy
            LoadingCricle.Visible = true;
            await Task.Delay(2000);
            LoadingCricle.Visible = false;
            Big_Logo.Visible = false;

            // Oczekiwanie przez 1 sekundę na pusty ekran
            await Task.Delay(500);

            // Przełącz do UserControl AccountType_USControl
            SwitchToAccountTypeControl();
        }

        private void SwitchToAccountTypeControl()
        {
            var accountTypeForm = new AccountType_Form(this);

            // Dodaj AccountType_Form do kontenera (na przykład Panel)
            // Zastąp 'panel1' nazwą Twojego kontenera
            this.Controls.Clear();
            this.Controls.Add(accountTypeForm);
        }
    }
}
