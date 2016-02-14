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
        }

        private void initKalkulacijaColumns()
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

        private void dgPredhodneKalkulacijeCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnDodajStavke_Click(object sender, EventArgs e)
        {
            OtpremnicaDTO otpremnica = new OtpremnicaDTO();
            fillObject(otpremnica);
            VeleprodajaUtil.getDAOFactory().getOtpremnicaDAO().insert(otpremnica);
        }
    }
}
