namespace Veleprodaja.view_dodaj
{
    partial class OtpremnicaDodajForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDatumOtpremnice = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dgPredhodneKalkulacije = new System.Windows.Forms.DataGridView();
            this.btnDodajStavke = new System.Windows.Forms.Button();
            this.cbKupac = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgPredhodneKalkulacije)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Datum otpremnice";
            // 
            // dtpDatumOtpremnice
            // 
            this.dtpDatumOtpremnice.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatumOtpremnice.Location = new System.Drawing.Point(143, 71);
            this.dtpDatumOtpremnice.Name = "dtpDatumOtpremnice";
            this.dtpDatumOtpremnice.Size = new System.Drawing.Size(390, 20);
            this.dtpDatumOtpremnice.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Predhodne otpremnice:";
            // 
            // dgPredhodneKalkulacije
            // 
            this.dgPredhodneKalkulacije.AllowUserToAddRows = false;
            this.dgPredhodneKalkulacije.AllowUserToDeleteRows = false;
            this.dgPredhodneKalkulacije.AllowUserToOrderColumns = true;
            this.dgPredhodneKalkulacije.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPredhodneKalkulacije.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPredhodneKalkulacije.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgPredhodneKalkulacije.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPredhodneKalkulacije.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgPredhodneKalkulacije.Location = new System.Drawing.Point(15, 213);
            this.dgPredhodneKalkulacije.Name = "dgPredhodneKalkulacije";
            this.dgPredhodneKalkulacije.ReadOnly = true;
            this.dgPredhodneKalkulacije.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgPredhodneKalkulacije.RowHeadersVisible = false;
            this.dgPredhodneKalkulacije.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPredhodneKalkulacije.Size = new System.Drawing.Size(774, 269);
            this.dgPredhodneKalkulacije.TabIndex = 21;
            // 
            // btnDodajStavke
            // 
            this.btnDodajStavke.Location = new System.Drawing.Point(382, 156);
            this.btnDodajStavke.Name = "btnDodajStavke";
            this.btnDodajStavke.Size = new System.Drawing.Size(151, 23);
            this.btnDodajStavke.TabIndex = 20;
            this.btnDodajStavke.Text = "Dodaj stavke";
            this.btnDodajStavke.UseVisualStyleBackColor = true;
            this.btnDodajStavke.Click += new System.EventHandler(this.btnDodajStavke_Click);
            // 
            // cbKupac
            // 
            this.cbKupac.FormattingEnabled = true;
            this.cbKupac.Location = new System.Drawing.Point(143, 33);
            this.cbKupac.Name = "cbKupac";
            this.cbKupac.Size = new System.Drawing.Size(390, 21);
            this.cbKupac.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Kupac";
            // 
            // OtpremnicaDodajForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 515);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpDatumOtpremnice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgPredhodneKalkulacije);
            this.Controls.Add(this.btnDodajStavke);
            this.Controls.Add(this.cbKupac);
            this.Controls.Add(this.label1);
            this.Name = "OtpremnicaDodajForm";
            this.Text = "OtpremnicaDodajForm";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cbKupac, 0);
            this.Controls.SetChildIndex(this.btnDodajStavke, 0);
            this.Controls.SetChildIndex(this.dgPredhodneKalkulacije, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.dtpDatumOtpremnice, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgPredhodneKalkulacije)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDatumOtpremnice;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.DataGridView dgPredhodneKalkulacije;
        private System.Windows.Forms.Button btnDodajStavke;
        private System.Windows.Forms.ComboBox cbKupac;
        private System.Windows.Forms.Label label1;
    }
}