using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veleprodaja.data.dto;

namespace Veleprodaja.view_dodaj
{
    public partial class OtpremnicaDodajForm : RootForm
    {
        public OtpremnicaDodajForm()
        {
            InitializeComponent();
            VeleprodajaUtil.initPartnerComboBox(cbKupac, -1);
            initOtpremnicaColumns();
            fillOtpremnice();
        }

        private void initOtpremnicaColumns()
        {
            dgPredhodneKalkulacije.Rows.Clear();
            dgPredhodneKalkulacije.Columns.Clear();
            DataGridViewColumn col = new DataGridViewTextBoxColumn();
            col.Name = "colObjekat";
            col.Visible = false;
            dgPredhodneKalkulacije.Columns.Add(col);
            col = new DataGridViewTextBoxColumn();
            col.Name = "colRedniBroj";
            col.HeaderText = "Redni broj";
            col.ToolTipText = "Redni broj kalkulacije";
            col.FillWeight = 50;
            dgPredhodneKalkulacije.Columns.Add(col);
            col = new DataGridViewTextBoxColumn();
            col.Name = "colDatum";
            col.HeaderText = "Datum";
            col.FillWeight = 50;
            dgPredhodneKalkulacije.Columns.Add(col);
            col = new DataGridViewTextBoxColumn();
            col.Name = "colKupac";
            col.HeaderText = "Kupac";
            col.FillWeight = 200;
            dgPredhodneKalkulacije.Columns.Add(col);
            col = new DataGridViewTextBoxColumn();
            col.Name = "colProdajnaVrijednost";
            col.HeaderText = "Prodajna vrijednost";
            col.FillWeight = 70;
            dgPredhodneKalkulacije.Columns.Add(col);
            col = new DataGridViewTextBoxColumn();
            col.Name = "colRabat";
            col.HeaderText = "Rabat";
            col.FillWeight = 70;
            dgPredhodneKalkulacije.Columns.Add(col);
            col = new DataGridViewTextBoxColumn();
            col.Name = "colIznos";
            col.HeaderText = "Iznos";
            col.FillWeight = 70;
            dgPredhodneKalkulacije.Columns.Add(col);
            col = new DataGridViewButtonColumn();
            col.Name = "colIzmjena";
            col.HeaderText = "Izmjeni";
            col.FillWeight = 50;
            dgPredhodneKalkulacije.Columns.Add(col);
            col = new DataGridViewButtonColumn();
            col.Name = "colIzmjenaStavke";
            col.FillWeight = 50;
            col.HeaderText = "Izmjeni stavke";
            dgPredhodneKalkulacije.Columns.Add(col);
            dgPredhodneKalkulacije.CellContentClick += new DataGridViewCellEventHandler(dgPredhodneKalkulacijeCellContentClick);
        }

        private void fillObject(OtpremnicaDTO otpremnica)
        {
            otpremnica.Partner =(PartnerDTO) cbKupac.Items[cbKupac.SelectedIndex];
            otpremnica.Datum = dtpDatumOtpremnice.Value;
            otpremnica.PoslovnaGodina = VeleprodajaUtil.PoslovnaGodina;
            
        }

        private void fillOtpremnice()
        {
            List<OtpremnicaDTO> lista = VeleprodajaUtil.getDAOFactory().getOtpremnicaDAO().getAll();
            foreach (OtpremnicaDTO otpremnica in lista)
            {
                dgPredhodneKalkulacije.Rows.Add(new object[] { otpremnica, otpremnica.RedniBroj, otpremnica.Datum.ToShortDateString(), otpremnica.Partner });
            }
        }

        private void dgPredhodneKalkulacijeCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 8)
                {
                    StavkaOtpremniceDodajForm sodf = new StavkaOtpremniceDodajForm((OtpremnicaDTO)dgPredhodneKalkulacije.Rows[e.RowIndex].Cells["colObject"].Value);
                    sodf.ShowDialog();
                }
            }
        }

        private void btnDodajStavke_Click(object sender, EventArgs e)
        {
            OtpremnicaDTO otpremnica = new OtpremnicaDTO();
            fillObject(otpremnica);
            VeleprodajaUtil.getDAOFactory().getOtpremnicaDAO().insert(otpremnica);
            fillOtpremnice();
        }
    }
}
