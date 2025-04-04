namespace PillPal
{
    partial class Form_Farmaceuta
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
            this.Farmaceuta_ikon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Farmaceuta_ikon)).BeginInit();
            this.SuspendLayout();
            // 
            // Farmaceuta_ikon
            // 
            this.Farmaceuta_ikon.Image = global::PillPal.Properties.Resources.Farmaceuta_ikona;
            this.Farmaceuta_ikon.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Farmaceuta_ikon.Location = new System.Drawing.Point(449, 174);
            this.Farmaceuta_ikon.Name = "Farmaceuta_ikon";
            this.Farmaceuta_ikon.Size = new System.Drawing.Size(346, 196);
            this.Farmaceuta_ikon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Farmaceuta_ikon.TabIndex = 1;
            this.Farmaceuta_ikon.TabStop = false;
            // 
            // Form_Farmaceuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(144)))), ((int)(((byte)(124)))));
            this.Controls.Add(this.Farmaceuta_ikon);
            this.Name = "Form_Farmaceuta";
            this.Size = new System.Drawing.Size(1245, 544);
            ((System.ComponentModel.ISupportInitialize)(this.Farmaceuta_ikon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Farmaceuta_ikon;
    }
}
