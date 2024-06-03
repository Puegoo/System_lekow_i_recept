namespace PillPal
{
    partial class Panel_Pacjent_Lekarze
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
            this.dataGridViewLekarze = new System.Windows.Forms.DataGridView();
            this.buttonFiltruj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMiasto = new System.Windows.Forms.ComboBox();
            this.comboBoxSpecjalizacja = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLekarze)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewLekarze
            // 
            this.dataGridViewLekarze.AllowUserToAddRows = false;
            this.dataGridViewLekarze.AllowUserToDeleteRows = false;
            this.dataGridViewLekarze.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLekarze.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLekarze.Location = new System.Drawing.Point(25, 147);
            this.dataGridViewLekarze.Name = "dataGridViewLekarze";
            this.dataGridViewLekarze.ReadOnly = true;
            this.dataGridViewLekarze.Size = new System.Drawing.Size(972, 528);
            this.dataGridViewLekarze.TabIndex = 0;
            // 
            // buttonFiltruj
            // 
            this.buttonFiltruj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(172)))), ((int)(((byte)(1)))));
            this.buttonFiltruj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFiltruj.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(172)))), ((int)(((byte)(1)))));
            this.buttonFiltruj.FlatAppearance.BorderSize = 0;
            this.buttonFiltruj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFiltruj.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonFiltruj.ForeColor = System.Drawing.Color.White;
            this.buttonFiltruj.Location = new System.Drawing.Point(876, 82);
            this.buttonFiltruj.Name = "buttonFiltruj";
            this.buttonFiltruj.Size = new System.Drawing.Size(121, 40);
            this.buttonFiltruj.TabIndex = 83;
            this.buttonFiltruj.Text = "Filtruj";
            this.buttonFiltruj.UseVisualStyleBackColor = false;
            this.buttonFiltruj.Click += new System.EventHandler(this.buttonFiltruj_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(33, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 30);
            this.label1.TabIndex = 86;
            this.label1.Text = "Miasto";
            // 
            // comboBoxMiasto
            // 
            this.comboBoxMiasto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMiasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMiasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBoxMiasto.FormattingEnabled = true;
            this.comboBoxMiasto.ItemHeight = 20;
            this.comboBoxMiasto.Location = new System.Drawing.Point(119, 96);
            this.comboBoxMiasto.Name = "comboBoxMiasto";
            this.comboBoxMiasto.Size = new System.Drawing.Size(262, 28);
            this.comboBoxMiasto.TabIndex = 87;
            // 
            // comboBoxSpecjalizacja
            // 
            this.comboBoxSpecjalizacja.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSpecjalizacja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSpecjalizacja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBoxSpecjalizacja.FormattingEnabled = true;
            this.comboBoxSpecjalizacja.ItemHeight = 20;
            this.comboBoxSpecjalizacja.Location = new System.Drawing.Point(573, 94);
            this.comboBoxSpecjalizacja.Name = "comboBoxSpecjalizacja";
            this.comboBoxSpecjalizacja.Size = new System.Drawing.Size(262, 28);
            this.comboBoxSpecjalizacja.TabIndex = 88;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 16.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(429, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 30);
            this.label3.TabIndex = 89;
            this.label3.Text = "Specjalizacje";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 28.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(29, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(270, 51);
            this.label6.TabIndex = 100;
            this.label6.Text = "Znajdź lekarza";
            // 
            // Panel_Pacjent_Lekarze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxSpecjalizacja);
            this.Controls.Add(this.comboBoxMiasto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonFiltruj);
            this.Controls.Add(this.dataGridViewLekarze);
            this.Name = "Panel_Pacjent_Lekarze";
            this.Size = new System.Drawing.Size(1023, 692);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLekarze)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewLekarze;
        private System.Windows.Forms.Button buttonFiltruj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMiasto;
        private System.Windows.Forms.ComboBox comboBoxSpecjalizacja;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
    }
}
