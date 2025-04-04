namespace PillPal
{
    partial class Panel_Farmaceuta_Magazyn
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
            this.dataGridViewMagazyn = new System.Windows.Forms.DataGridView();
            this.labelInfo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonOdswiez = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMagazyn)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMagazyn
            // 
            this.dataGridViewMagazyn.AllowUserToAddRows = false;
            this.dataGridViewMagazyn.AllowUserToDeleteRows = false;
            this.dataGridViewMagazyn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMagazyn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMagazyn.Location = new System.Drawing.Point(18, 128);
            this.dataGridViewMagazyn.Name = "dataGridViewMagazyn";
            this.dataGridViewMagazyn.ReadOnly = true;
            this.dataGridViewMagazyn.Size = new System.Drawing.Size(985, 537);
            this.dataGridViewMagazyn.TabIndex = 0;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelInfo.Location = new System.Drawing.Point(11, 75);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(110, 37);
            this.labelInfo.TabIndex = 131;
            this.labelInfo.Text = "Apteka:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 28.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(9, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 51);
            this.label6.TabIndex = 130;
            this.label6.Text = "Magazyn:";
            // 
            // buttonOdswiez
            // 
            this.buttonOdswiez.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(144)))), ((int)(((byte)(124)))));
            this.buttonOdswiez.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOdswiez.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(172)))), ((int)(((byte)(1)))));
            this.buttonOdswiez.FlatAppearance.BorderSize = 0;
            this.buttonOdswiez.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOdswiez.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonOdswiez.ForeColor = System.Drawing.Color.White;
            this.buttonOdswiez.Location = new System.Drawing.Point(882, 75);
            this.buttonOdswiez.Name = "buttonOdswiez";
            this.buttonOdswiez.Size = new System.Drawing.Size(121, 40);
            this.buttonOdswiez.TabIndex = 137;
            this.buttonOdswiez.Text = "Odśwież";
            this.buttonOdswiez.UseVisualStyleBackColor = false;
            this.buttonOdswiez.Click += new System.EventHandler(this.ButtonOdswiez_Click);
            // 
            // Panel_Farmaceuta_Magazyn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonOdswiez);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridViewMagazyn);
            this.Name = "Panel_Farmaceuta_Magazyn";
            this.Size = new System.Drawing.Size(1023, 692);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMagazyn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMagazyn;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonOdswiez;
    }
}
