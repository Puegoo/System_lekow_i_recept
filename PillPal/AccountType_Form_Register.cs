using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PillPal
{
    public partial class AccountType_Form_Register : UserControl
    {
        private DateTime[] animationStartTimes;
        private TimeSpan animationDuration = TimeSpan.FromMilliseconds(300); // Czas trwania animacji (500 milisekund)
        private Timer[] colorTimers;
        private Loading_Win loadingWin;

        public AccountType_Form_Register(Loading_Win loadingWin)
        {
            InitializeComponent();

            this.loadingWin = loadingWin;
            this.Height = 800;
            this.Width = 1245;

            // Inicjalizacja tablicy czasów rozpoczęcia animacji i timerów dla paneli
            animationStartTimes = new DateTime[] { DateTime.MinValue, DateTime.MinValue, DateTime.MinValue };
            colorTimers = new Timer[] { new Timer(), new Timer(), new Timer() };

            // Ustawienie obsługi zdarzeń dla paneli
            AddPanelHoverAnimation(Pacjent_Panel, 0);
            AddPanelHoverAnimation(Lekarz_Panel, 1);
            AddPanelHoverAnimation(Farmaceuta_Panel, 2);

            RoundCornersOfPanel(Pacjent_Panel);
            RoundCornersOfPanel(Lekarz_Panel);
            RoundCornersOfPanel(Farmaceuta_Panel);

            // Inicjalizacja timerów do animacji
            foreach (Timer timer in colorTimers)
            {
                timer.Interval = 10; // Dostosuj interwał dla płynniejszej animacji
            }

            foreach (Control control in Pacjent_Panel.Controls)
            {
                control.MouseClick += Pacjent_Panel_MouseClick;
            }

            foreach (Control control in Lekarz_Panel.Controls)
            {
                control.MouseClick += Lekarz_Panel_MouseClick;
            }

            foreach (Control control in Farmaceuta_Panel.Controls)
            {
                control.MouseClick += Farmaceuta_Panel_MouseClick;
            }
        }

        private void AddPanelHoverAnimation(Panel panel, int index)
        {
            foreach (Control control in panel.Controls)
            {
                control.MouseEnter += (sender, e) => Panel_MouseEnter(panel, index, sender, e);
                control.MouseLeave += (sender, e) => Panel_MouseLeave(panel, index, sender, e);
            }
        }

        private void Panel_MouseEnter(Panel panel, int index, object sender, EventArgs e)
        {
            AnimatePanelColor(panel, index, panel.BackColor, Color.WhiteSmoke);
        }

        private void Panel_MouseLeave(Panel panel, int index, object sender, EventArgs e)
        {
            AnimatePanelColor(panel, index, panel.BackColor, Color.White);
        }

        private void AnimatePanelColor(Panel panel, int index, Color fromColor, Color toColor)
        {
            // Zapisanie czasu rozpoczęcia animacji
            animationStartTimes[index] = DateTime.Now;

            // Obsługa zdarzenia Tick timera do animacji
            colorTimers[index].Tick += (sender, e) =>
            {
                // Obliczenie postępu animacji
                float progress = (float)(DateTime.Now - animationStartTimes[index]).TotalMilliseconds / (float)animationDuration.TotalMilliseconds;

                if (progress >= 1)
                {
                    // Zakończenie animacji
                    colorTimers[index].Enabled = false;
                    panel.BackColor = toColor;
                }
                else
                {
                    // Obliczenie pośredniego koloru
                    Color intermediateColor = Color.FromArgb(
                        (int)(fromColor.R + (toColor.R - fromColor.R) * progress),
                        (int)(fromColor.G + (toColor.G - fromColor.G) * progress),
                        (int)(fromColor.B + (toColor.B - fromColor.B) * progress)
                    );
                    panel.BackColor = intermediateColor;
                }
            };

            // Rozpoczęcie animacji
            colorTimers[index].Enabled = true;
        }

        private void Pacjent_Panel_MouseClick(object sender, MouseEventArgs e)
        {
            Form_Register.Controls.Clear();
            Form_Pacjent formPacjent = new Form_Pacjent(this); // Przekaż referencję do bieżącego formularza

            Form_Register.Controls.Remove(label6);
            Form_Register.Controls.Add(formPacjent);
            this.VerticalScroll.Value = this.VerticalScroll.Maximum;
        }

        private void Lekarz_Panel_MouseClick(object sender, MouseEventArgs e)
        {
            Form_Register.Controls.Clear();
            Form_Lekarz formLekarz = new Form_Lekarz(this);

            Form_Register.Controls.Remove(label6);
            Form_Register.Controls.Add(formLekarz);
            this.VerticalScroll.Value = this.VerticalScroll.Maximum;
        }

        private void Farmaceuta_Panel_MouseClick(object sender, MouseEventArgs e)
        {
            Form_Register.Controls.Clear();
            Form_Farmaceuta formFarmaceuta = new Form_Farmaceuta(this);

            Form_Register.Controls.Remove(label6);
            Form_Register.Controls.Add(formFarmaceuta);
            this.VerticalScroll.Value = this.VerticalScroll.Maximum;
        }

        private void RoundCornersOfPanel(Panel panel)
        {
            GraphicsPath path = new GraphicsPath();
            int cornerRadius = 10; // Możesz dostosować wartość zaokrąglenia do swoich preferencji

            // Górny lewy róg
            path.AddArc(new Rectangle(0, 0, cornerRadius * 2, cornerRadius * 2), 180, 90);
            // Górny prawy róg
            path.AddArc(new Rectangle(panel.Width - cornerRadius * 2, 0, cornerRadius * 2, cornerRadius * 2), 270, 90);
            // Dolny prawy róg
            path.AddArc(new Rectangle(panel.Width - cornerRadius * 2, panel.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2), 0, 90);
            // Dolny lewy róg
            path.AddArc(new Rectangle(0, panel.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2), 90, 90);
            path.CloseAllFigures();

            panel.Region = new Region(path);
        }

        private void Return_Btn_Click(object sender, EventArgs e)
        {
            // Utwórz nową instancję AccountType_Form
            var accountTypeForm = new AccountType_Form(loadingWin);
            this.AutoScroll = false;

            // Dodaj AccountType_Form do kontenera (na przykład Panel)
            this.Controls.Clear();
            this.Controls.Add(accountTypeForm);
        }

        public void InvokeReturnButtonClick()
        {
            Return_Btn_Click(this, EventArgs.Empty);
        }
    }
}
