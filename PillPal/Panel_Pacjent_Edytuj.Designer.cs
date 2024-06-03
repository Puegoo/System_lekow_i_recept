namespace PillPal
{
    partial class Panel_Pacjent_Edytuj
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonZapiszZmiany = new System.Windows.Forms.Button();
            this.ElblImie = new System.Windows.Forms.TextBox();
            this.ElblNazwisko = new System.Windows.Forms.TextBox();
            this.ElblPesel = new System.Windows.Forms.TextBox();
            this.EComboPlec = new System.Windows.Forms.ComboBox();
            this.EDataTime = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(40, 399);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 37);
            this.label4.TabIndex = 18;
            this.label4.Text = "Płeć:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(40, 327);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(210, 37);
            this.label5.TabIndex = 17;
            this.label5.Text = "Data urodzenia:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(40, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 37);
            this.label3.TabIndex = 16;
            this.label3.Text = "PESEL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(40, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 37);
            this.label2.TabIndex = 15;
            this.label2.Text = "Nazwisko:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(40, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 37);
            this.label1.TabIndex = 14;
            this.label1.Text = "Imię:";
            // 
            // buttonZapiszZmiany
            // 
            this.buttonZapiszZmiany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(172)))), ((int)(((byte)(1)))));
            this.buttonZapiszZmiany.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonZapiszZmiany.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(172)))), ((int)(((byte)(1)))));
            this.buttonZapiszZmiany.FlatAppearance.BorderSize = 0;
            this.buttonZapiszZmiany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonZapiszZmiany.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonZapiszZmiany.ForeColor = System.Drawing.Color.White;
            this.buttonZapiszZmiany.Location = new System.Drawing.Point(47, 506);
            this.buttonZapiszZmiany.Name = "buttonZapiszZmiany";
            this.buttonZapiszZmiany.Size = new System.Drawing.Size(121, 40);
            this.buttonZapiszZmiany.TabIndex = 84;
            this.buttonZapiszZmiany.Text = "Zapisz zaminy";
            this.buttonZapiszZmiany.UseVisualStyleBackColor = false;
            this.buttonZapiszZmiany.Click += new System.EventHandler(this.buttonZapiszZmiany_Click);
            // 
            // ElblImie
            // 
            this.ElblImie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ElblImie.Location = new System.Drawing.Point(304, 127);
            this.ElblImie.Multiline = true;
            this.ElblImie.Name = "ElblImie";
            this.ElblImie.Size = new System.Drawing.Size(334, 30);
            this.ElblImie.TabIndex = 93;
            // 
            // ElblNazwisko
            // 
            this.ElblNazwisko.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ElblNazwisko.Location = new System.Drawing.Point(304, 196);
            this.ElblNazwisko.Multiline = true;
            this.ElblNazwisko.Name = "ElblNazwisko";
            this.ElblNazwisko.Size = new System.Drawing.Size(334, 30);
            this.ElblNazwisko.TabIndex = 94;
            // 
            // ElblPesel
            // 
            this.ElblPesel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ElblPesel.Location = new System.Drawing.Point(304, 258);
            this.ElblPesel.Multiline = true;
            this.ElblPesel.Name = "ElblPesel";
            this.ElblPesel.Size = new System.Drawing.Size(334, 30);
            this.ElblPesel.TabIndex = 95;
            // 
            // EComboPlec
            // 
            this.EComboPlec.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EComboPlec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EComboPlec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.EComboPlec.FormattingEnabled = true;
            this.EComboPlec.ItemHeight = 20;
            this.EComboPlec.Location = new System.Drawing.Point(304, 408);
            this.EComboPlec.Name = "EComboPlec";
            this.EComboPlec.Size = new System.Drawing.Size(334, 28);
            this.EComboPlec.TabIndex = 97;
            // 
            // EDataTime
            // 
            this.EDataTime.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EDataTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.EDataTime.Location = new System.Drawing.Point(304, 336);
            this.EDataTime.MaxDate = new System.DateTime(2024, 5, 9, 0, 0, 0, 0);
            this.EDataTime.MinDate = new System.DateTime(1901, 1, 1, 0, 0, 0, 0);
            this.EDataTime.Name = "EDataTime";
            this.EDataTime.Size = new System.Drawing.Size(334, 26);
            this.EDataTime.TabIndex = 98;
            this.EDataTime.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 28.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(38, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(342, 51);
            this.label6.TabIndex = 99;
            this.label6.Text = "Edytuj dane konta:";
            // 
            // Panel_Pacjent_Edytuj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.EDataTime);
            this.Controls.Add(this.EComboPlec);
            this.Controls.Add(this.ElblPesel);
            this.Controls.Add(this.ElblNazwisko);
            this.Controls.Add(this.ElblImie);
            this.Controls.Add(this.buttonZapiszZmiany);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Panel_Pacjent_Edytuj";
            this.Size = new System.Drawing.Size(1023, 692);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonZapiszZmiany;
        private System.Windows.Forms.TextBox ElblImie;
        private System.Windows.Forms.TextBox ElblNazwisko;
        private System.Windows.Forms.TextBox ElblPesel;
        private System.Windows.Forms.ComboBox EComboPlec;
        private System.Windows.Forms.DateTimePicker EDataTime;
        private System.Windows.Forms.Label label6;
    }
}
