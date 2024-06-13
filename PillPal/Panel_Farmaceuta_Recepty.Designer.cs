namespace PillPal
{
    partial class Panel_Farmaceuta_Recepty
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
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxKodRecepty = new System.Windows.Forms.TextBox();
            this.buttonWyszukaj = new System.Windows.Forms.Button();
            this.dataGridViewRecepty = new System.Windows.Forms.DataGridView();
            this.buttonSzczegoly = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecepty)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 28.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(33, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(332, 51);
            this.label6.TabIndex = 131;
            this.label6.Text = "Wyszukaj recepte:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(35, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 37);
            this.label1.TabIndex = 130;
            this.label1.Text = "Podaj kod recepty:";
            // 
            // textBoxKodRecepty
            // 
            this.textBoxKodRecepty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxKodRecepty.Location = new System.Drawing.Point(284, 117);
            this.textBoxKodRecepty.Multiline = true;
            this.textBoxKodRecepty.Name = "textBoxKodRecepty";
            this.textBoxKodRecepty.Size = new System.Drawing.Size(334, 30);
            this.textBoxKodRecepty.TabIndex = 133;
            // 
            // buttonWyszukaj
            // 
            this.buttonWyszukaj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(144)))), ((int)(((byte)(124)))));
            this.buttonWyszukaj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonWyszukaj.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(172)))), ((int)(((byte)(1)))));
            this.buttonWyszukaj.FlatAppearance.BorderSize = 0;
            this.buttonWyszukaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWyszukaj.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonWyszukaj.ForeColor = System.Drawing.Color.White;
            this.buttonWyszukaj.Location = new System.Drawing.Point(644, 110);
            this.buttonWyszukaj.Name = "buttonWyszukaj";
            this.buttonWyszukaj.Size = new System.Drawing.Size(121, 40);
            this.buttonWyszukaj.TabIndex = 132;
            this.buttonWyszukaj.Text = "Szukaj";
            this.buttonWyszukaj.UseVisualStyleBackColor = false;
            this.buttonWyszukaj.Click += new System.EventHandler(this.buttonSzukaj_Click);
            // 
            // dataGridViewRecepty
            // 
            this.dataGridViewRecepty.AllowUserToAddRows = false;
            this.dataGridViewRecepty.AllowUserToDeleteRows = false;
            this.dataGridViewRecepty.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRecepty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRecepty.Location = new System.Drawing.Point(42, 179);
            this.dataGridViewRecepty.Name = "dataGridViewRecepty";
            this.dataGridViewRecepty.ReadOnly = true;
            this.dataGridViewRecepty.Size = new System.Drawing.Size(934, 430);
            this.dataGridViewRecepty.TabIndex = 134;
            this.dataGridViewRecepty.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRecepty_CellDoubleClick);
            // 
            // buttonSzczegoly
            // 
            this.buttonSzczegoly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(144)))), ((int)(((byte)(124)))));
            this.buttonSzczegoly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSzczegoly.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(172)))), ((int)(((byte)(1)))));
            this.buttonSzczegoly.FlatAppearance.BorderSize = 0;
            this.buttonSzczegoly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSzczegoly.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonSzczegoly.ForeColor = System.Drawing.Color.White;
            this.buttonSzczegoly.Location = new System.Drawing.Point(42, 625);
            this.buttonSzczegoly.Name = "buttonSzczegoly";
            this.buttonSzczegoly.Size = new System.Drawing.Size(161, 40);
            this.buttonSzczegoly.TabIndex = 135;
            this.buttonSzczegoly.Text = "Zobacz szczegóły";
            this.buttonSzczegoly.UseVisualStyleBackColor = false;
            this.buttonSzczegoly.Click += new System.EventHandler(this.buttonSzczegoly_Click);
            // 
            // Panel_Farmaceuta_Recepty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSzczegoly);
            this.Controls.Add(this.dataGridViewRecepty);
            this.Controls.Add(this.textBoxKodRecepty);
            this.Controls.Add(this.buttonWyszukaj);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Name = "Panel_Farmaceuta_Recepty";
            this.Size = new System.Drawing.Size(1023, 692);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecepty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxKodRecepty;
        private System.Windows.Forms.Button buttonWyszukaj;
        private System.Windows.Forms.DataGridView dataGridViewRecepty;
        private System.Windows.Forms.Button buttonSzczegoly;
    }
}
