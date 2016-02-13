namespace Veleprodaja.view_dodaj
{
    partial class JedinicaMjereDodajForm
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
            this.tbxSifra = new System.Windows.Forms.TextBox();
            this.tbxOpis = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // tbxSifra
            // 
            this.tbxSifra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxSifra.Location = new System.Drawing.Point(109, 56);
            this.tbxSifra.Name = "tbxSifra";
            this.tbxSifra.Size = new System.Drawing.Size(149, 20);
            this.tbxSifra.TabIndex = 2;
            // 
            // tbxOpis
            // 
            this.tbxOpis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxOpis.Location = new System.Drawing.Point(109, 109);
            this.tbxOpis.Name = "tbxOpis";
            this.tbxOpis.Size = new System.Drawing.Size(149, 20);
            this.tbxOpis.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sifra jedinice mjere";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Opis";
            // 
            // JedinicaMjereDodajForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxOpis);
            this.Controls.Add(this.tbxSifra);
            this.Name = "JedinicaMjereDodajForm";
            this.Text = "JedinicaMjereDodajForm";
            this.Controls.SetChildIndex(this.btnSacuvaj, 0);
            this.Controls.SetChildIndex(this.btnOdustani, 0);
            this.Controls.SetChildIndex(this.tbxSifra, 0);
            this.Controls.SetChildIndex(this.tbxOpis, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxSifra;
        private System.Windows.Forms.TextBox tbxOpis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}