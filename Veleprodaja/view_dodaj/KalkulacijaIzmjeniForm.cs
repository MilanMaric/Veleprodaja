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
    public partial class KalkulacijaIzmjeniForm : Form
    {
        private KalkulacijaDTO kalkulacija = null;
        public KalkulacijaIzmjeniForm(KalkulacijaDTO kalkulacija)
        {
            InitializeComponent();
            VeleprodajaUtil.initPartnerComboBox(cbDobavljac, kalkulacija.Partner.Jib);
            tbxBrojFaktureDobavljaca.Text = kalkulacija.BrojFaktureDobavljaca;
            dtpDatumKalkulacije.Value = kalkulacija.Datum;
            this.kalkulacija = kalkulacija;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fillObject();
            VeleprodajaUtil.getDAOFactory().getKalkulacijaDAO().update(kalkulacija);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void fillObject()
        {
            kalkulacija.BrojFaktureDobavljaca = tbxBrojFaktureDobavljaca.Text;
            kalkulacija.Partner = (PartnerDTO)cbDobavljac.Items[cbDobavljac.SelectedIndex];
            kalkulacija.Datum = dtpDatumKalkulacije.Value;
        }
    }
}
