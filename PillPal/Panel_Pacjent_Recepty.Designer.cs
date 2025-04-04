namespace PillPal
{
    partial class Panel_Pacjent_Recepty
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.buttonOdswiez = new System.Windows.Forms.Button();
            this.dataGridViewRecepty = new System.Windows.Forms.DataGridView();
            this.buttonSzczegoly = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecepty)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 28.25F, System.Drawing.FontStyle.Bold);
            this.lblInfo.Location = new System.Drawing.Point(36, 34);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(334, 51);
            this.lblInfo.TabIndex = 100;
            this.lblInfo.Text = "Dostępne recepty:";
            // 
            // buttonOdswiez
            // 
            this.buttonOdswiez.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(172)))), ((int)(((byte)(1)))));
            this.buttonOdswiez.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOdswiez.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(172)))), ((int)(((byte)(1)))));
            this.buttonOdswiez.FlatAppearance.BorderSize = 0;
            this.buttonOdswiez.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOdswiez.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonOdswiez.ForeColor = System.Drawing.Color.White;
            this.buttonOdswiez.Location = new System.Drawing.Point(212, 627);
            this.buttonOdswiez.Name = "buttonOdswiez";
            this.buttonOdswiez.Size = new System.Drawing.Size(121, 40);
            this.buttonOdswiez.TabIndex = 101;
            this.buttonOdswiez.Text = "Odśwież";
            this.buttonOdswiez.UseVisualStyleBackColor = false;
            this.buttonOdswiez.Click += new System.EventHandler(this.buttonOdswiez_Click);
            // 
            // dataGridViewRecepty
            // 
            this.dataGridViewRecepty.AllowUserToAddRows = false;
            this.dataGridViewRecepty.AllowUserToDeleteRows = false;
            this.dataGridViewRecepty.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRecepty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRecepty.Location = new System.Drawing.Point(45, 115);
            this.dataGridViewRecepty.Name = "dataGridViewRecepty";
            this.dataGridViewRecepty.ReadOnly = true;
            this.dataGridViewRecepty.Size = new System.Drawing.Size(932, 506);
            this.dataGridViewRecepty.TabIndex = 102;
            // 
            // buttonSzczegoly
            // 
            this.buttonSzczegoly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(172)))), ((int)(((byte)(1)))));
            this.buttonSzczegoly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSzczegoly.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(172)))), ((int)(((byte)(1)))));
            this.buttonSzczegoly.FlatAppearance.BorderSize = 0;
            this.buttonSzczegoly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSzczegoly.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonSzczegoly.ForeColor = System.Drawing.Color.White;
            this.buttonSzczegoly.Location = new System.Drawing.Point(45, 627);
            this.buttonSzczegoly.Name = "buttonSzczegoly";
            this.buttonSzczegoly.Size = new System.Drawing.Size(161, 40);
            this.buttonSzczegoly.TabIndex = 103;
            this.buttonSzczegoly.Text = "Zobacz szczegóły";
            this.buttonSzczegoly.UseVisualStyleBackColor = false;
            this.buttonSzczegoly.Click += new System.EventHandler(this.buttonSzczegoly_Click);
            // 
            // Panel_Pacjent_Recepty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSzczegoly);
            this.Controls.Add(this.dataGridViewRecepty);
            this.Controls.Add(this.buttonOdswiez);
            this.Controls.Add(this.lblInfo);
            this.Name = "Panel_Pacjent_Recepty";
            this.Size = new System.Drawing.Size(1023, 692);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecepty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button buttonOdswiez;
        private System.Windows.Forms.DataGridView dataGridViewRecepty;
        private System.Windows.Forms.Button buttonSzczegoly;
    }
}
