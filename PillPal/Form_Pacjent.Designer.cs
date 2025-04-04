namespace PillPal
{
    partial class Form_Pacjent
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
            this.Pacjent_ikon = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ImieTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NazwiskoTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PeselTextBox = new System.Windows.Forms.TextBox();
            this.ZarejestrujButton = new System.Windows.Forms.Button();
            this.Check1_Picture = new System.Windows.Forms.PictureBox();
            this.Check2_Picture = new System.Windows.Forms.PictureBox();
            this.PlecComboBox = new System.Windows.Forms.ComboBox();
            this.Check3_Picture = new System.Windows.Forms.PictureBox();
            this.Check4_Picture = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DataUrodzeniaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.Check5_Picture = new System.Windows.Forms.PictureBox();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.HasloTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Pacjent_ikon)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Check1_Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Check2_Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Check3_Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Check4_Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Check5_Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // Pacjent_ikon
            // 
            this.Pacjent_ikon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pacjent_ikon.Image = global::PillPal.Properties.Resources.Pacjent_ikona;
            this.Pacjent_ikon.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Pacjent_ikon.Location = new System.Drawing.Point(0, 0);
            this.Pacjent_ikon.Name = "Pacjent_ikon";
            this.Pacjent_ikon.Size = new System.Drawing.Size(400, 628);
            this.Pacjent_ikon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Pacjent_ikon.TabIndex = 1;
            this.Pacjent_ikon.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(172)))), ((int)(((byte)(1)))));
            this.panel1.Controls.Add(this.Pacjent_ikon);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 628);
            this.panel1.TabIndex = 2;
            // 
            // ImieTextBox
            // 
            this.ImieTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ImieTextBox.Location = new System.Drawing.Point(834, 73);
            this.ImieTextBox.Multiline = true;
            this.ImieTextBox.Name = "ImieTextBox";
            this.ImieTextBox.Size = new System.Drawing.Size(334, 30);
            this.ImieTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(828, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Imię:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(828, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nazwisko:";
            // 
            // NazwiskoTextBox
            // 
            this.NazwiskoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NazwiskoTextBox.Location = new System.Drawing.Point(834, 157);
            this.NazwiskoTextBox.Multiline = true;
            this.NazwiskoTextBox.Name = "NazwiskoTextBox";
            this.NazwiskoTextBox.Size = new System.Drawing.Size(334, 30);
            this.NazwiskoTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(828, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 32);
            this.label3.TabIndex = 10;
            this.label3.Text = "Pesel:";
            // 
            // PeselTextBox
            // 
            this.PeselTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PeselTextBox.Location = new System.Drawing.Point(834, 248);
            this.PeselTextBox.Multiline = true;
            this.PeselTextBox.Name = "PeselTextBox";
            this.PeselTextBox.Size = new System.Drawing.Size(334, 30);
            this.PeselTextBox.TabIndex = 9;
            this.PeselTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PeselTextBox_KeyPress);
            // 
            // ZarejestrujButton
            // 
            this.ZarejestrujButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(172)))), ((int)(((byte)(1)))));
            this.ZarejestrujButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZarejestrujButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(172)))), ((int)(((byte)(1)))));
            this.ZarejestrujButton.FlatAppearance.BorderSize = 0;
            this.ZarejestrujButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ZarejestrujButton.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.ZarejestrujButton.ForeColor = System.Drawing.Color.White;
            this.ZarejestrujButton.Location = new System.Drawing.Point(412, 585);
            this.ZarejestrujButton.Name = "ZarejestrujButton";
            this.ZarejestrujButton.Size = new System.Drawing.Size(121, 40);
            this.ZarejestrujButton.TabIndex = 17;
            this.ZarejestrujButton.Text = "Zarejestruj się";
            this.ZarejestrujButton.UseVisualStyleBackColor = false;
            this.ZarejestrujButton.Click += new System.EventHandler(this.ZarejestrujButton_Click);
            // 
            // Check1_Picture
            // 
            this.Check1_Picture.Location = new System.Drawing.Point(1174, 73);
            this.Check1_Picture.Name = "Check1_Picture";
            this.Check1_Picture.Size = new System.Drawing.Size(32, 30);
            this.Check1_Picture.TabIndex = 18;
            this.Check1_Picture.TabStop = false;
            // 
            // Check2_Picture
            // 
            this.Check2_Picture.Location = new System.Drawing.Point(1174, 157);
            this.Check2_Picture.Name = "Check2_Picture";
            this.Check2_Picture.Size = new System.Drawing.Size(32, 30);
            this.Check2_Picture.TabIndex = 19;
            this.Check2_Picture.TabStop = false;
            // 
            // PlecComboBox
            // 
            this.PlecComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlecComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.PlecComboBox.FormattingEnabled = true;
            this.PlecComboBox.ItemHeight = 20;
            this.PlecComboBox.Location = new System.Drawing.Point(834, 332);
            this.PlecComboBox.Name = "PlecComboBox";
            this.PlecComboBox.Size = new System.Drawing.Size(334, 28);
            this.PlecComboBox.TabIndex = 25;
            this.PlecComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PlecComboBox_KeyPress);
            // 
            // Check3_Picture
            // 
            this.Check3_Picture.Location = new System.Drawing.Point(1174, 248);
            this.Check3_Picture.Name = "Check3_Picture";
            this.Check3_Picture.Size = new System.Drawing.Size(32, 30);
            this.Check3_Picture.TabIndex = 20;
            this.Check3_Picture.TabStop = false;
            // 
            // Check4_Picture
            // 
            this.Check4_Picture.Location = new System.Drawing.Point(1174, 330);
            this.Check4_Picture.Name = "Check4_Picture";
            this.Check4_Picture.Size = new System.Drawing.Size(32, 30);
            this.Check4_Picture.TabIndex = 26;
            this.Check4_Picture.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(828, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 32);
            this.label4.TabIndex = 24;
            this.label4.Text = "Płeć:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(828, 381);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 32);
            this.label5.TabIndex = 27;
            this.label5.Text = "Data urodzenia:";
            // 
            // DataUrodzeniaDateTimePicker
            // 
            this.DataUrodzeniaDateTimePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataUrodzeniaDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.DataUrodzeniaDateTimePicker.Location = new System.Drawing.Point(834, 421);
            this.DataUrodzeniaDateTimePicker.MaxDate = new System.DateTime(2024, 5, 9, 0, 0, 0, 0);
            this.DataUrodzeniaDateTimePicker.MinDate = new System.DateTime(1901, 1, 1, 0, 0, 0, 0);
            this.DataUrodzeniaDateTimePicker.Name = "DataUrodzeniaDateTimePicker";
            this.DataUrodzeniaDateTimePicker.Size = new System.Drawing.Size(334, 26);
            this.DataUrodzeniaDateTimePicker.TabIndex = 28;
            this.DataUrodzeniaDateTimePicker.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // Check5_Picture
            // 
            this.Check5_Picture.Location = new System.Drawing.Point(1174, 417);
            this.Check5_Picture.Name = "Check5_Picture";
            this.Check5_Picture.Size = new System.Drawing.Size(32, 30);
            this.Check5_Picture.TabIndex = 29;
            this.Check5_Picture.TabStop = false;
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LoginTextBox.Location = new System.Drawing.Point(412, 70);
            this.LoginTextBox.Multiline = true;
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(334, 30);
            this.LoginTextBox.TabIndex = 83;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(752, 164);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 30);
            this.pictureBox5.TabIndex = 82;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Location = new System.Drawing.Point(752, 70);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(32, 30);
            this.pictureBox6.TabIndex = 81;
            this.pictureBox6.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(406, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 32);
            this.label11.TabIndex = 78;
            this.label11.Text = "Login:";
            // 
            // HasloTextBox
            // 
            this.HasloTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.HasloTextBox.Location = new System.Drawing.Point(412, 164);
            this.HasloTextBox.Multiline = true;
            this.HasloTextBox.Name = "HasloTextBox";
            this.HasloTextBox.PasswordChar = '*';
            this.HasloTextBox.Size = new System.Drawing.Size(334, 30);
            this.HasloTextBox.TabIndex = 80;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(406, 129);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 32);
            this.label12.TabIndex = 79;
            this.label12.Text = "Hasło:";
            // 
            // Form_Pacjent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.LoginTextBox);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.HasloTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.Check5_Picture);
            this.Controls.Add(this.DataUrodzeniaDateTimePicker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Check4_Picture);
            this.Controls.Add(this.PlecComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Check3_Picture);
            this.Controls.Add(this.Check2_Picture);
            this.Controls.Add(this.Check1_Picture);
            this.Controls.Add(this.ZarejestrujButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PeselTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NazwiskoTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ImieTextBox);
            this.Controls.Add(this.panel1);
            this.Name = "Form_Pacjent";
            this.Size = new System.Drawing.Size(1228, 628);
            ((System.ComponentModel.ISupportInitialize)(this.Pacjent_ikon)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Check1_Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Check2_Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Check3_Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Check4_Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Check5_Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Pacjent_ikon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox ImieTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NazwiskoTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PeselTextBox;
        private System.Windows.Forms.Button ZarejestrujButton;
        private System.Windows.Forms.PictureBox Check1_Picture;
        private System.Windows.Forms.PictureBox Check2_Picture;
        private System.Windows.Forms.ComboBox PlecComboBox;
        private System.Windows.Forms.PictureBox Check3_Picture;
        private System.Windows.Forms.PictureBox Check4_Picture;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DataUrodzeniaDateTimePicker;
        private System.Windows.Forms.PictureBox Check5_Picture;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox HasloTextBox;
        private System.Windows.Forms.Label label12;
    }
}
