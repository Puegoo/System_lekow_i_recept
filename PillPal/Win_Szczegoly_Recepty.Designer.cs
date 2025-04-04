namespace PillPal
{
    partial class Win_Szczegoly_Recepty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Win_Szczegoly_Recepty));
            this.listViewLeki = new System.Windows.Forms.ListView();
            this.buttonZamknij = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.labelKodRecepty = new System.Windows.Forms.Label();
            this.textBoxKodRecepty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDataWystawienia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewLeki
            // 
            this.listViewLeki.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.listViewLeki.HideSelection = false;
            this.listViewLeki.Location = new System.Drawing.Point(16, 341);
            this.listViewLeki.Name = "listViewLeki";
            this.listViewLeki.Size = new System.Drawing.Size(547, 347);
            this.listViewLeki.TabIndex = 125;
            this.listViewLeki.UseCompatibleStateImageBehavior = false;
            this.listViewLeki.View = System.Windows.Forms.View.Details;
            // 
            // buttonZamknij
            // 
            this.buttonZamknij.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(172)))), ((int)(((byte)(1)))));
            this.buttonZamknij.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonZamknij.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(172)))), ((int)(((byte)(1)))));
            this.buttonZamknij.FlatAppearance.BorderSize = 0;
            this.buttonZamknij.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonZamknij.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonZamknij.ForeColor = System.Drawing.Color.White;
            this.buttonZamknij.Location = new System.Drawing.Point(442, 709);
            this.buttonZamknij.Name = "buttonZamknij";
            this.buttonZamknij.Size = new System.Drawing.Size(121, 40);
            this.buttonZamknij.TabIndex = 124;
            this.buttonZamknij.Text = "Zamknij";
            this.buttonZamknij.UseVisualStyleBackColor = false;
            this.buttonZamknij.Click += new System.EventHandler(this.buttonZamknij_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 28.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(130, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(331, 51);
            this.label6.TabIndex = 123;
            this.label6.Text = "Szczegóły recepty";
            // 
            // labelKodRecepty
            // 
            this.labelKodRecepty.AutoSize = true;
            this.labelKodRecepty.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelKodRecepty.Location = new System.Drawing.Point(9, 130);
            this.labelKodRecepty.Name = "labelKodRecepty";
            this.labelKodRecepty.Size = new System.Drawing.Size(171, 37);
            this.labelKodRecepty.TabIndex = 122;
            this.labelKodRecepty.Text = "Kod recepty:";
            // 
            // textBoxKodRecepty
            // 
            this.textBoxKodRecepty.Enabled = false;
            this.textBoxKodRecepty.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.textBoxKodRecepty.Location = new System.Drawing.Point(315, 136);
            this.textBoxKodRecepty.Name = "textBoxKodRecepty";
            this.textBoxKodRecepty.Size = new System.Drawing.Size(219, 31);
            this.textBoxKodRecepty.TabIndex = 126;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(9, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 37);
            this.label1.TabIndex = 127;
            this.label1.Text = "Data wystawienia:";
            // 
            // textBoxDataWystawienia
            // 
            this.textBoxDataWystawienia.Enabled = false;
            this.textBoxDataWystawienia.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.textBoxDataWystawienia.Location = new System.Drawing.Point(315, 188);
            this.textBoxDataWystawienia.Name = "textBoxDataWystawienia";
            this.textBoxDataWystawienia.Size = new System.Drawing.Size(219, 31);
            this.textBoxDataWystawienia.TabIndex = 128;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 37);
            this.label2.TabIndex = 129;
            this.label2.Text = "Status:";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Enabled = false;
            this.textBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.textBoxStatus.Location = new System.Drawing.Point(315, 236);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(219, 31);
            this.textBoxStatus.TabIndex = 130;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(12, 301);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 37);
            this.label3.TabIndex = 131;
            this.label3.Text = "Leki:";
            // 
            // Win_Szczegoly_Recepty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 761);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxDataWystawienia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxKodRecepty);
            this.Controls.Add(this.listViewLeki);
            this.Controls.Add(this.buttonZamknij);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelKodRecepty);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Win_Szczegoly_Recepty";
            this.Text = "Win_Szczegoly_Recepty";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewLeki;
        private System.Windows.Forms.Button buttonZamknij;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelKodRecepty;
        private System.Windows.Forms.TextBox textBoxKodRecepty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDataWystawienia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Label label3;
    }
}