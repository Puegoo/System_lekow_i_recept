namespace PillPal
{
    partial class Win_Dodaj_Recepte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Win_Dodaj_Recepte));
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxLeki = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownIlosc = new System.Windows.Forms.NumericUpDown();
            this.buttonDodajLek = new System.Windows.Forms.Button();
            this.buttonZatwierdzRecepte = new System.Windows.Forms.Button();
            this.buttonAnuluj = new System.Windows.Forms.Button();
            this.listViewLeki = new System.Windows.Forms.ListView();
            this.lblInfoPacjent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIlosc)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(5, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 37);
            this.label1.TabIndex = 105;
            this.label1.Text = "Wybierz lek:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 28.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(155, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(264, 51);
            this.label6.TabIndex = 113;
            this.label6.Text = "Dodaj recepte";
            // 
            // comboBoxLeki
            // 
            this.comboBoxLeki.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLeki.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLeki.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBoxLeki.FormattingEnabled = true;
            this.comboBoxLeki.ItemHeight = 20;
            this.comboBoxLeki.Location = new System.Drawing.Point(179, 98);
            this.comboBoxLeki.Name = "comboBoxLeki";
            this.comboBoxLeki.Size = new System.Drawing.Size(393, 28);
            this.comboBoxLeki.TabIndex = 114;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(5, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 37);
            this.label2.TabIndex = 115;
            this.label2.Text = "Ilość sztuk:";
            // 
            // numericUpDownIlosc
            // 
            this.numericUpDownIlosc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.numericUpDownIlosc.Location = new System.Drawing.Point(179, 176);
            this.numericUpDownIlosc.Name = "numericUpDownIlosc";
            this.numericUpDownIlosc.Size = new System.Drawing.Size(393, 26);
            this.numericUpDownIlosc.TabIndex = 116;
            // 
            // buttonDodajLek
            // 
            this.buttonDodajLek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(93)))), ((int)(((byte)(122)))));
            this.buttonDodajLek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDodajLek.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(172)))), ((int)(((byte)(1)))));
            this.buttonDodajLek.FlatAppearance.BorderSize = 0;
            this.buttonDodajLek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDodajLek.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonDodajLek.ForeColor = System.Drawing.Color.White;
            this.buttonDodajLek.Location = new System.Drawing.Point(12, 242);
            this.buttonDodajLek.Name = "buttonDodajLek";
            this.buttonDodajLek.Size = new System.Drawing.Size(121, 40);
            this.buttonDodajLek.TabIndex = 117;
            this.buttonDodajLek.Text = "Dodaj lek";
            this.buttonDodajLek.UseVisualStyleBackColor = false;
            this.buttonDodajLek.Click += new System.EventHandler(this.buttonDodajLek_Click);
            // 
            // buttonZatwierdzRecepte
            // 
            this.buttonZatwierdzRecepte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(93)))), ((int)(((byte)(122)))));
            this.buttonZatwierdzRecepte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonZatwierdzRecepte.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(172)))), ((int)(((byte)(1)))));
            this.buttonZatwierdzRecepte.FlatAppearance.BorderSize = 0;
            this.buttonZatwierdzRecepte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonZatwierdzRecepte.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonZatwierdzRecepte.ForeColor = System.Drawing.Color.White;
            this.buttonZatwierdzRecepte.Location = new System.Drawing.Point(12, 709);
            this.buttonZatwierdzRecepte.Name = "buttonZatwierdzRecepte";
            this.buttonZatwierdzRecepte.Size = new System.Drawing.Size(146, 40);
            this.buttonZatwierdzRecepte.TabIndex = 119;
            this.buttonZatwierdzRecepte.Text = "Zatwierdź receptę\n";
            this.buttonZatwierdzRecepte.UseVisualStyleBackColor = false;
            this.buttonZatwierdzRecepte.Click += new System.EventHandler(this.buttonZatwierdzRecepte_Click);
            // 
            // buttonAnuluj
            // 
            this.buttonAnuluj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(93)))), ((int)(((byte)(122)))));
            this.buttonAnuluj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAnuluj.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(172)))), ((int)(((byte)(1)))));
            this.buttonAnuluj.FlatAppearance.BorderSize = 0;
            this.buttonAnuluj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAnuluj.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonAnuluj.ForeColor = System.Drawing.Color.White;
            this.buttonAnuluj.Location = new System.Drawing.Point(451, 709);
            this.buttonAnuluj.Name = "buttonAnuluj";
            this.buttonAnuluj.Size = new System.Drawing.Size(121, 40);
            this.buttonAnuluj.TabIndex = 120;
            this.buttonAnuluj.Text = "Anuluj";
            this.buttonAnuluj.UseVisualStyleBackColor = false;
            // 
            // listViewLeki
            // 
            this.listViewLeki.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.listViewLeki.HideSelection = false;
            this.listViewLeki.Location = new System.Drawing.Point(12, 300);
            this.listViewLeki.Name = "listViewLeki";
            this.listViewLeki.Size = new System.Drawing.Size(560, 369);
            this.listViewLeki.TabIndex = 121;
            this.listViewLeki.UseCompatibleStateImageBehavior = false;
            this.listViewLeki.View = System.Windows.Forms.View.Details;
            // 
            // lblInfoPacjent
            // 
            this.lblInfoPacjent.AutoSize = true;
            this.lblInfoPacjent.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblInfoPacjent.Location = new System.Drawing.Point(172, 242);
            this.lblInfoPacjent.Name = "lblInfoPacjent";
            this.lblInfoPacjent.Size = new System.Drawing.Size(38, 37);
            this.lblInfoPacjent.TabIndex = 122;
            this.lblInfoPacjent.Text = "...";
            // 
            // Win_Dodaj_Recepte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 761);
            this.Controls.Add(this.lblInfoPacjent);
            this.Controls.Add(this.listViewLeki);
            this.Controls.Add(this.buttonAnuluj);
            this.Controls.Add(this.buttonZatwierdzRecepte);
            this.Controls.Add(this.buttonDodajLek);
            this.Controls.Add(this.numericUpDownIlosc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxLeki);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Win_Dodaj_Recepte";
            this.Text = "Win_Dodaj_Recepte";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIlosc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxLeki;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownIlosc;
        private System.Windows.Forms.Button buttonDodajLek;
        private System.Windows.Forms.Button buttonZatwierdzRecepte;
        private System.Windows.Forms.Button buttonAnuluj;
        private System.Windows.Forms.ListView listViewLeki;
        private System.Windows.Forms.Label lblInfoPacjent;
    }
}