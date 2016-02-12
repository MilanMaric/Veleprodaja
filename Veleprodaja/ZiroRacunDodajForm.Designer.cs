namespace Veleprodaja
{
    partial class ZiroRacunDodajForm
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
            this.cbBanka = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDodajBanku = new System.Windows.Forms.Button();
            this.tbBrojZiroRacuna = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbBanka
            // 
            this.cbBanka.FormattingEnabled = true;
            this.cbBanka.Location = new System.Drawing.Point(121, 84);
            this.cbBanka.Name = "cbBanka";
            this.cbBanka.Size = new System.Drawing.Size(164, 21);
            this.cbBanka.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Banka:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Broj ziro racuna:";
            // 
            // btnDodajBanku
            // 
            this.btnDodajBanku.Location = new System.Drawing.Point(291, 82);
            this.btnDodajBanku.Name = "btnDodajBanku";
            this.btnDodajBanku.Size = new System.Drawing.Size(30, 23);
            this.btnDodajBanku.TabIndex = 3;
            this.btnDodajBanku.Text = "+";
            this.btnDodajBanku.UseVisualStyleBackColor = true;
            // 
            // tbBrojZiroRacuna
            // 
            this.tbBrojZiroRacuna.Location = new System.Drawing.Point(121, 31);
            this.tbBrojZiroRacuna.Name = "tbBrojZiroRacuna";
            this.tbBrojZiroRacuna.Size = new System.Drawing.Size(200, 20);
            this.tbBrojZiroRacuna.TabIndex = 6;
            // 
            // ZiroRacunDodajForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 174);
            this.Controls.Add(this.tbBrojZiroRacuna);
            this.Controls.Add(this.btnDodajBanku);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbBanka);
            this.Name = "ZiroRacunDodajForm";
            this.Text = "ZiroRacunDodajForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbBanka;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDodajBanku;
        private System.Windows.Forms.TextBox tbBrojZiroRacuna;
    }
}