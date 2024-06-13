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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ZarejestrujButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Check5_Picture = new System.Windows.Forms.PictureBox();
            this.ImieTextBox = new System.Windows.Forms.TextBox();
            this.DataUrodzeniaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.NazwiskoTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Check4_Picture = new System.Windows.Forms.PictureBox();
            this.PlecComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Check1_Picture = new System.Windows.Forms.PictureBox();
            this.Check2_Picture = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.HasloTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.AptekaComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Farmaceuta_ikon)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Check5_Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Check4_Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Check1_Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Check2_Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // Farmaceuta_ikon
            // 
            this.Farmaceuta_ikon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Farmaceuta_ikon.Image = global::PillPal.Properties.Resources.Farmaceuta_ikona;
            this.Farmaceuta_ikon.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Farmaceuta_ikon.Location = new System.Drawing.Point(0, 0);
            this.Farmaceuta_ikon.Name = "Farmaceuta_ikon";
            this.Farmaceuta_ikon.Size = new System.Drawing.Size(400, 628);
            this.Farmaceuta_ikon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Farmaceuta_ikon.TabIndex = 1;
            this.Farmaceuta_ikon.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(144)))), ((int)(((byte)(124)))));
            this.panel1.Controls.Add(this.Farmaceuta_ikon);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 628);
            this.panel1.TabIndex = 4;
            // 
            // ZarejestrujButton
            // 
            this.ZarejestrujButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(144)))), ((int)(((byte)(124)))));
            this.ZarejestrujButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZarejestrujButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(172)))), ((int)(((byte)(1)))));
            this.ZarejestrujButton.FlatAppearance.BorderSize = 0;
            this.ZarejestrujButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ZarejestrujButton.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.ZarejestrujButton.ForeColor = System.Drawing.Color.White;
            this.ZarejestrujButton.Location = new System.Drawing.Point(412, 585);
            this.ZarejestrujButton.Name = "ZarejestrujButton";
            this.ZarejestrujButton.Size = new System.Drawing.Size(121, 40);
            this.ZarejestrujButton.TabIndex = 36;
            this.ZarejestrujButton.Text = "Zarejestruj się";
            this.ZarejestrujButton.UseVisualStyleBackColor = false;
            this.ZarejestrujButton.Click += new System.EventHandler(this.ZarejestrujButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(144)))), ((int)(((byte)(124)))));
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.Check5_Picture);
            this.panel2.Controls.Add(this.ImieTextBox);
            this.panel2.Controls.Add(this.DataUrodzeniaDateTimePicker);
            this.panel2.Controls.Add(this.NazwiskoTextBox);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.Check4_Picture);
            this.panel2.Controls.Add(this.PlecComboBox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.Check1_Picture);
            this.panel2.Controls.Add(this.Check2_Picture);
            this.panel2.Location = new System.Drawing.Point(845, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 628);
            this.panel2.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(90, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(224, 32);
            this.label9.TabIndex = 77;
            this.label9.Text = "Dane podstawowe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 32);
            this.label1.TabIndex = 63;
            this.label1.Text = "Imię:";
            // 
            // Check5_Picture
            // 
            this.Check5_Picture.Location = new System.Drawing.Point(357, 383);
            this.Check5_Picture.Name = "Check5_Picture";
            this.Check5_Picture.Size = new System.Drawing.Size(32, 30);
            this.Check5_Picture.TabIndex = 76;
            this.Check5_Picture.TabStop = false;
            // 
            // ImieTextBox
            // 
            this.ImieTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ImieTextBox.Location = new System.Drawing.Point(17, 119);
            this.ImieTextBox.Multiline = true;
            this.ImieTextBox.Name = "ImieTextBox";
            this.ImieTextBox.Size = new System.Drawing.Size(334, 30);
            this.ImieTextBox.TabIndex = 62;
            // 
            // DataUrodzeniaDateTimePicker
            // 
            this.DataUrodzeniaDateTimePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataUrodzeniaDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.DataUrodzeniaDateTimePicker.Location = new System.Drawing.Point(17, 387);
            this.DataUrodzeniaDateTimePicker.MaxDate = new System.DateTime(2024, 5, 9, 0, 0, 0, 0);
            this.DataUrodzeniaDateTimePicker.MinDate = new System.DateTime(1901, 1, 1, 0, 0, 0, 0);
            this.DataUrodzeniaDateTimePicker.Name = "DataUrodzeniaDateTimePicker";
            this.DataUrodzeniaDateTimePicker.Size = new System.Drawing.Size(334, 26);
            this.DataUrodzeniaDateTimePicker.TabIndex = 75;
            this.DataUrodzeniaDateTimePicker.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // NazwiskoTextBox
            // 
            this.NazwiskoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NazwiskoTextBox.Location = new System.Drawing.Point(17, 203);
            this.NazwiskoTextBox.Multiline = true;
            this.NazwiskoTextBox.Name = "NazwiskoTextBox";
            this.NazwiskoTextBox.Size = new System.Drawing.Size(334, 30);
            this.NazwiskoTextBox.TabIndex = 64;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(11, 347);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 32);
            this.label5.TabIndex = 74;
            this.label5.Text = "Data urodzenia:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 32);
            this.label2.TabIndex = 65;
            this.label2.Text = "Nazwisko:";
            // 
            // Check4_Picture
            // 
            this.Check4_Picture.Location = new System.Drawing.Point(357, 296);
            this.Check4_Picture.Name = "Check4_Picture";
            this.Check4_Picture.Size = new System.Drawing.Size(32, 30);
            this.Check4_Picture.TabIndex = 73;
            this.Check4_Picture.TabStop = false;
            // 
            // PlecComboBox
            // 
            this.PlecComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlecComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.PlecComboBox.FormattingEnabled = true;
            this.PlecComboBox.ItemHeight = 20;
            this.PlecComboBox.Location = new System.Drawing.Point(17, 298);
            this.PlecComboBox.Name = "PlecComboBox";
            this.PlecComboBox.Size = new System.Drawing.Size(334, 28);
            this.PlecComboBox.TabIndex = 72;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(11, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 32);
            this.label4.TabIndex = 71;
            this.label4.Text = "Płeć:";
            // 
            // Check1_Picture
            // 
            this.Check1_Picture.Location = new System.Drawing.Point(357, 119);
            this.Check1_Picture.Name = "Check1_Picture";
            this.Check1_Picture.Size = new System.Drawing.Size(32, 30);
            this.Check1_Picture.TabIndex = 68;
            this.Check1_Picture.TabStop = false;
            // 
            // Check2_Picture
            // 
            this.Check2_Picture.Location = new System.Drawing.Point(357, 203);
            this.Check2_Picture.Name = "Check2_Picture";
            this.Check2_Picture.Size = new System.Drawing.Size(32, 30);
            this.Check2_Picture.TabIndex = 69;
            this.Check2_Picture.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(498, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(250, 32);
            this.label6.TabIndex = 81;
            this.label6.Text = "Dane specjalistyczne";
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LoginTextBox.Location = new System.Drawing.Point(412, 119);
            this.LoginTextBox.Multiline = true;
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(334, 30);
            this.LoginTextBox.TabIndex = 93;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(406, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 32);
            this.label11.TabIndex = 87;
            this.label11.Text = "Login:";
            // 
            // HasloTextBox
            // 
            this.HasloTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.HasloTextBox.Location = new System.Drawing.Point(412, 213);
            this.HasloTextBox.Multiline = true;
            this.HasloTextBox.Name = "HasloTextBox";
            this.HasloTextBox.PasswordChar = '*';
            this.HasloTextBox.Size = new System.Drawing.Size(334, 30);
            this.HasloTextBox.TabIndex = 89;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(406, 178);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 32);
            this.label12.TabIndex = 88;
            this.label12.Text = "Hasło:";
            // 
            // AptekaComboBox
            // 
            this.AptekaComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AptekaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AptekaComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AptekaComboBox.FormattingEnabled = true;
            this.AptekaComboBox.ItemHeight = 20;
            this.AptekaComboBox.Location = new System.Drawing.Point(412, 298);
            this.AptekaComboBox.Name = "AptekaComboBox";
            this.AptekaComboBox.Size = new System.Drawing.Size(409, 28);
            this.AptekaComboBox.TabIndex = 78;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(406, 263);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 32);
            this.label10.TabIndex = 90;
            this.label10.Text = "Apteka";
            // 
            // Form_Farmaceuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LoginTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.HasloTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.AptekaComboBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ZarejestrujButton);
            this.Controls.Add(this.panel1);
            this.Name = "Form_Farmaceuta";
            this.Size = new System.Drawing.Size(1245, 628);
            ((System.ComponentModel.ISupportInitialize)(this.Farmaceuta_ikon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Check5_Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Check4_Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Check1_Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Check2_Picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Farmaceuta_ikon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ZarejestrujButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox HasloTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox AptekaComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Check5_Picture;
        private System.Windows.Forms.TextBox ImieTextBox;
        private System.Windows.Forms.DateTimePicker DataUrodzeniaDateTimePicker;
        private System.Windows.Forms.TextBox NazwiskoTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox Check4_Picture;
        private System.Windows.Forms.ComboBox PlecComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox Check1_Picture;
        private System.Windows.Forms.PictureBox Check2_Picture;
    }
}
