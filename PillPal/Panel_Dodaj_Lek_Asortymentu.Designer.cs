namespace PillPal
{
    partial class Panel_Dodaj_Lek_Asortymentu
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
            this.textBoxIlosc = new System.Windows.Forms.TextBox();
            this.buttonAnuluj = new System.Windows.Forms.Button();
            this.textBoxCena = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonDodajLek = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxLeki = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxIlosc
            // 
            this.textBoxIlosc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxIlosc.Location = new System.Drawing.Point(214, 159);
            this.textBoxIlosc.Multiline = true;
            this.textBoxIlosc.Name = "textBoxIlosc";
            this.textBoxIlosc.Size = new System.Drawing.Size(393, 30);
            this.textBoxIlosc.TabIndex = 136;
            this.textBoxIlosc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxIlosc_KeyPress);
            // 
            // buttonAnuluj
            // 
            this.buttonAnuluj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(144)))), ((int)(((byte)(124)))));
            this.buttonAnuluj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAnuluj.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(172)))), ((int)(((byte)(1)))));
            this.buttonAnuluj.FlatAppearance.BorderSize = 0;
            this.buttonAnuluj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAnuluj.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonAnuluj.ForeColor = System.Drawing.Color.White;
            this.buttonAnuluj.Location = new System.Drawing.Point(214, 297);
            this.buttonAnuluj.Name = "buttonAnuluj";
            this.buttonAnuluj.Size = new System.Drawing.Size(121, 40);
            this.buttonAnuluj.TabIndex = 135;
            this.buttonAnuluj.Text = "Anuluj";
            this.buttonAnuluj.UseVisualStyleBackColor = false;
            this.buttonAnuluj.Click += new System.EventHandler(this.buttonAnuluj_Click);
            // 
            // textBoxCena
            // 
            this.textBoxCena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxCena.Location = new System.Drawing.Point(214, 229);
            this.textBoxCena.Multiline = true;
            this.textBoxCena.Name = "textBoxCena";
            this.textBoxCena.Size = new System.Drawing.Size(393, 30);
            this.textBoxCena.TabIndex = 134;
            this.textBoxCena.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxCena_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(31, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 37);
            this.label3.TabIndex = 133;
            this.label3.Text = "Cena:";
            // 
            // buttonDodajLek
            // 
            this.buttonDodajLek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(144)))), ((int)(((byte)(124)))));
            this.buttonDodajLek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDodajLek.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(172)))), ((int)(((byte)(1)))));
            this.buttonDodajLek.FlatAppearance.BorderSize = 0;
            this.buttonDodajLek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDodajLek.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonDodajLek.ForeColor = System.Drawing.Color.White;
            this.buttonDodajLek.Location = new System.Drawing.Point(38, 297);
            this.buttonDodajLek.Name = "buttonDodajLek";
            this.buttonDodajLek.Size = new System.Drawing.Size(161, 40);
            this.buttonDodajLek.TabIndex = 132;
            this.buttonDodajLek.Text = "Dodaj lek";
            this.buttonDodajLek.UseVisualStyleBackColor = false;
            this.buttonDodajLek.Click += new System.EventHandler(this.buttonDodajLek_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(31, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 37);
            this.label2.TabIndex = 131;
            this.label2.Text = "Ilość sztuk:";
            // 
            // comboBoxLeki
            // 
            this.comboBoxLeki.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLeki.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLeki.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBoxLeki.FormattingEnabled = true;
            this.comboBoxLeki.ItemHeight = 20;
            this.comboBoxLeki.Location = new System.Drawing.Point(214, 96);
            this.comboBoxLeki.Name = "comboBoxLeki";
            this.comboBoxLeki.Size = new System.Drawing.Size(393, 28);
            this.comboBoxLeki.TabIndex = 130;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 28.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(29, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(429, 51);
            this.label6.TabIndex = 129;
            this.label6.Text = "Dodaj lek do magazynu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(31, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 37);
            this.label1.TabIndex = 128;
            this.label1.Text = "Wybierz lek:";
            // 
            // Panel_Dodaj_Lek_Asortymentu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxIlosc);
            this.Controls.Add(this.buttonAnuluj);
            this.Controls.Add(this.textBoxCena);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonDodajLek);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxLeki);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Name = "Panel_Dodaj_Lek_Asortymentu";
            this.Size = new System.Drawing.Size(1023, 692);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxIlosc;
        private System.Windows.Forms.Button buttonAnuluj;
        private System.Windows.Forms.TextBox textBoxCena;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonDodajLek;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxLeki;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
    }
}
