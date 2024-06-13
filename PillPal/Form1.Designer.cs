namespace PillPal
{
    partial class Loading_Win
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading_Win));
            this.LoadingCricle = new System.Windows.Forms.PictureBox();
            this.Big_Logo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingCricle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Big_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadingCricle
            // 
            this.LoadingCricle.Image = global::PillPal.Properties.Resources.LoadingCircle;
            resources.ApplyResources(this.LoadingCricle, "LoadingCricle");
            this.LoadingCricle.Name = "LoadingCricle";
            this.LoadingCricle.TabStop = false;
            // 
            // Big_Logo
            // 
            this.Big_Logo.Image = global::PillPal.Properties.Resources.Logo_Border;
            resources.ApplyResources(this.Big_Logo, "Big_Logo");
            this.Big_Logo.Name = "Big_Logo";
            this.Big_Logo.TabStop = false;
            // 
            // Loading_Win
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(84)))));
            this.Controls.Add(this.LoadingCricle);
            this.Controls.Add(this.Big_Logo);
            this.MaximizeBox = false;
            this.Name = "Loading_Win";
            this.Load += new System.EventHandler(this.Identification_Win_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LoadingCricle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Big_Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Big_Logo;
        private System.Windows.Forms.PictureBox LoadingCricle;
    }
}

