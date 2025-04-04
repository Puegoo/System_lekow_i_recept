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
            LoadingCricle.Visible = true;
            await Task.Delay(2000);
            LoadingCricle.Visible = false;
            Big_Logo.Visible = false;

            await Task.Delay(500);

            SwitchToAccountTypeControl();
        }

        private void SwitchToAccountTypeControl()

        {
            var accountTypeForm = new AccountType_Form();

            this.Controls.Clear();
            this.Controls.Add(accountTypeForm);
        }
    }
}
