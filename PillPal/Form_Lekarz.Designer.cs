namespace PillPal
{
    partial class Form_Lekarz
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
            this.Lekarz_ikon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Lekarz_ikon)).BeginInit();
            this.SuspendLayout();
            // 
            // Lekarz_ikon
            // 
            this.Lekarz_ikon.Image = global::PillPal.Properties.Resources.Lekarz_ikona1;
            this.Lekarz_ikon.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Lekarz_ikon.Location = new System.Drawing.Point(449, 168);
            this.Lekarz_ikon.Name = "Lekarz_ikon";
            this.Lekarz_ikon.Size = new System.Drawing.Size(346, 209);
            this.Lekarz_ikon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Lekarz_ikon.TabIndex = 1;
            this.Lekarz_ikon.TabStop = false;
            // 
            // Form_Lekarz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(93)))), ((int)(((byte)(122)))));
            this.Controls.Add(this.Lekarz_ikon);
            this.Name = "Form_Lekarz";
            this.Size = new System.Drawing.Size(1245, 544);
            ((System.ComponentModel.ISupportInitialize)(this.Lekarz_ikon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Lekarz_ikon;
    }
}
