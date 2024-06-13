namespace PillPal
{
    partial class Panel_Lekarz_Recepty
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
            this.SearchButton = new System.Windows.Forms.Button();
            this.textBoxPesel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PacjentLabel = new System.Windows.Forms.Label();
            this.buttonDodajRecepte = new System.Windows.Forms.Button();
            this.dataGridViewPacjenci = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPacjenci)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(93)))), ((int)(((byte)(122)))));
            this.SearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(172)))), ((int)(((byte)(1)))));
            this.SearchButton.FlatAppearance.BorderSize = 0;
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchButton.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.SearchButton.ForeColor = System.Drawing.Color.White;
            this.SearchButton.Location = new System.Drawing.Point(464, 93);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(121, 40);
            this.SearchButton.TabIndex = 87;
            this.SearchButton.Text = "Szukaj";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // textBoxPesel
            // 
            this.textBoxPesel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxPesel.Location = new System.Drawing.Point(104, 100);
            this.textBoxPesel.Multiline = true;
            this.textBoxPesel.Name = "textBoxPesel";
            this.textBoxPesel.Size = new System.Drawing.Size(334, 30);
            this.textBoxPesel.TabIndex = 93;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 28.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(30, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(294, 51);
            this.label6.TabIndex = 102;
            this.label6.Text = "Znajdź pacjenta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(34, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 30);
            this.label1.TabIndex = 101;
            this.label1.Text = "Pesel";
            // 
            // PacjentLabel
            // 
            this.PacjentLabel.AutoSize = true;
            this.PacjentLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 16.25F, System.Drawing.FontStyle.Bold);
            this.PacjentLabel.Location = new System.Drawing.Point(34, 197);
            this.PacjentLabel.Name = "PacjentLabel";
            this.PacjentLabel.Size = new System.Drawing.Size(90, 30);
            this.PacjentLabel.TabIndex = 103;
            this.PacjentLabel.Text = "Pacjent:";
            // 
            // buttonDodajRecepte
            // 
            this.buttonDodajRecepte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(93)))), ((int)(((byte)(122)))));
            this.buttonDodajRecepte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDodajRecepte.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(172)))), ((int)(((byte)(1)))));
            this.buttonDodajRecepte.FlatAppearance.BorderSize = 0;
            this.buttonDodajRecepte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDodajRecepte.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonDodajRecepte.ForeColor = System.Drawing.Color.White;
            this.buttonDodajRecepte.Location = new System.Drawing.Point(613, 93);
            this.buttonDodajRecepte.Name = "buttonDodajRecepte";
            this.buttonDodajRecepte.Size = new System.Drawing.Size(121, 40);
            this.buttonDodajRecepte.TabIndex = 104;
            this.buttonDodajRecepte.Text = "Dodaj Receptę";
            this.buttonDodajRecepte.UseVisualStyleBackColor = false;
            this.buttonDodajRecepte.Click += new System.EventHandler(this.AddReceptaButton_Click);
            // 
            // dataGridViewPacjenci
            // 
            this.dataGridViewPacjenci.AllowUserToAddRows = false;
            this.dataGridViewPacjenci.AllowUserToDeleteRows = false;
            this.dataGridViewPacjenci.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPacjenci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPacjenci.Location = new System.Drawing.Point(39, 244);
            this.dataGridViewPacjenci.Name = "dataGridViewPacjenci";
            this.dataGridViewPacjenci.ReadOnly = true;
            this.dataGridViewPacjenci.Size = new System.Drawing.Size(849, 427);
            this.dataGridViewPacjenci.TabIndex = 105;
            // 
            // Panel_Lekarz_Recepty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewPacjenci);
            this.Controls.Add(this.buttonDodajRecepte);
            this.Controls.Add(this.PacjentLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPesel);
            this.Controls.Add(this.SearchButton);
            this.Name = "Panel_Lekarz_Recepty";
            this.Size = new System.Drawing.Size(1023, 692);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPacjenci)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox textBoxPesel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PacjentLabel;
        private System.Windows.Forms.Button buttonDodajRecepte;
        private System.Windows.Forms.DataGridView dataGridViewPacjenci;
    }
}
