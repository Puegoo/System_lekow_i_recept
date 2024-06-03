namespace PillPal
{
    partial class Form_Pacjent
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

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.Pacjent_ikon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Pacjent_ikon)).BeginInit();
            this.SuspendLayout();
            // 
            // Pacjent_ikon
            // 
            this.Pacjent_ikon.Image = global::PillPal.Properties.Resources.Pacjent_ikona;
            this.Pacjent_ikon.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Pacjent_ikon.Location = new System.Drawing.Point(449, 177);
            this.Pacjent_ikon.Name = "Pacjent_ikon";
            this.Pacjent_ikon.Size = new System.Drawing.Size(346, 196);
            this.Pacjent_ikon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Pacjent_ikon.TabIndex = 1;
            this.Pacjent_ikon.TabStop = false;
            // 
            // Form_Pacjent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(172)))), ((int)(((byte)(1)))));
            this.Controls.Add(this.Pacjent_ikon);
            this.Name = "Form_Pacjent";
            this.Size = new System.Drawing.Size(1245, 544);
            ((System.ComponentModel.ISupportInitialize)(this.Pacjent_ikon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Pacjent_ikon;
    }
}
