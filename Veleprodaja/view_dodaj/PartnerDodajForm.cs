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

namespace Veleprodaja
{
    public partial class PartnerDodajForm : DodajForm
    {
        public PartnerDodajForm()
        {
            InitializeComponent();
            VeleprodajaUtil.initMjestoComboBox(cbMjesto);
        }


        private void btnDodajMjesto_Click(object sender, EventArgs e)
        {
            MjestoDodajForm mdf = new MjestoDodajForm();
            if (mdf.ShowDialog() == DialogResult.OK)
            {
                VeleprodajaUtil.initMjestoComboBox(cbMjesto);
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            PartnerDTO partner = fillObject();
            VeleprodajaUtil.getDAOFactory().getPartnerDAO().insert(partner);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private PartnerDTO fillObject()
        {
            PartnerDTO partner = new PartnerDTO();
            partner.Jib = int.Parse(tbxJib.Text);
            partner.Naziv = tbxNaziv.Text;
            partner.Adresa = tbxAdresa.Text;
            partner.Mjesto =(MjestoDTO) cbMjesto.Items[cbMjesto.SelectedIndex];
            return partner;
        }
    }
}
