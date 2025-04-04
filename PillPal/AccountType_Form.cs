using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace PillPal
{
    public partial class AccountType_Form : UserControl
    {
        private DateTime[] animationStartTimes;
        private TimeSpan animationDuration = TimeSpan.FromMilliseconds(300); // Czas trwania animacji (500 milisekund)
        private Timer[] colorTimers;

        public AccountType_Form()
        {
            InitializeComponent();

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

        private void AccountType_Form_Load(object sender, EventArgs e)
        {

        }

        private void Sign_Up_Click(object sender, EventArgs e)
        {
            // Utwórz nową instancję AccountType_Form_Register
            var accountTypeFormRegister = new AccountType_Form_Register();

            // Dodaj AccountType_Form_Register do kontenera (na przykład Panel)
            this.Controls.Clear();
            this.Controls.Add(accountTypeFormRegister);
        }

        private void PillPal_Logo_Click(object sender, EventArgs e)
        {

        }

        private void Welcome_Label_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

