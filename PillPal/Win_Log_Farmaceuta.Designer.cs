namespace PillPal
{
    partial class Win_Log_Farmaceuta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Win_Log_Farmaceuta));
            this.Zalogujsie = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.HasloTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Zalogujsie
            // 
            this.Zalogujsie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(144)))), ((int)(((byte)(124)))));
            this.Zalogujsie.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Zalogujsie.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(172)))), ((int)(((byte)(1)))));
            this.Zalogujsie.FlatAppearance.BorderSize = 0;
            this.Zalogujsie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Zalogujsie.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.Zalogujsie.ForeColor = System.Drawing.Color.White;
            this.Zalogujsie.Location = new System.Drawing.Point(451, 308);
            this.Zalogujsie.Name = "Zalogujsie";
            this.Zalogujsie.Size = new System.Drawing.Size(121, 40);
            this.Zalogujsie.TabIndex = 88;
            this.Zalogujsie.Text = "Zaloguj się";
            this.Zalogujsie.UseVisualStyleBackColor = false;
            this.Zalogujsie.Click += new System.EventHandler(this.Zalogujsie_Click);
            // 
            // labelError
            // 
            this.labelError.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelError.ForeColor = System.Drawing.Color.IndianRed;
            this.labelError.Location = new System.Drawing.Point(117, 103);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 17);
            this.labelError.TabIndex = 93;
            this.labelError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LoginTextBox.Location = new System.Drawing.Point(134, 152);
            this.LoginTextBox.Multiline = true;
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(334, 30);
            this.LoginTextBox.TabIndex = 92;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(128, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 32);
            this.label11.TabIndex = 89;
            this.label11.Text = "Login:";
            // 
            // HasloTextBox
            // 
            this.HasloTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.HasloTextBox.Location = new System.Drawing.Point(134, 246);
            this.HasloTextBox.Multiline = true;
            this.HasloTextBox.Name = "HasloTextBox";
            this.HasloTextBox.PasswordChar = '*';
            this.HasloTextBox.Size = new System.Drawing.Size(334, 30);
            this.HasloTextBox.TabIndex = 91;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(128, 211);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 32);
            this.label12.TabIndex = 90;
            this.label12.Text = "Hasło:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PillPal.Properties.Resources.Farmaceuta_ikona;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(584, 101);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 83;
            this.pictureBox1.TabStop = false;
            // 
            // Win_Log_Farmaceuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.LoginTextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.HasloTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.Zalogujsie);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Win_Log_Farmaceuta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Logujesz się jako farmaceuta";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Zalogujsie;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox HasloTextBox;
        private System.Windows.Forms.Label label12;
    }
}