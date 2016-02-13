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
    public partial class RobaDodajForm : DodajForm
    {
        private RobaDTO roba = null;
        public RobaDodajForm()
        {
            InitializeComponent();
            VeleprodajaUtil.initJedinicaMjereComboBox(cbJedinicaMjere);
        }

        public RobaDodajForm(RobaDTO roba)
        {
            InitializeComponent();
            this.roba = roba;
            fillControls();
        }
        private RobaDTO fillObject()
        {
            RobaDTO roba = new RobaDTO();
            if (string.IsNullOrEmpty(tbxSifra.Text))
            {
                return null;
            }
            else
            {
                roba.SifraRoba = int.Parse(tbxSifra.Text);
            }
            roba.Naziv = tbxNaziv.Text;
            roba.JedinicaMjere =(JedinicaMjereDTO) cbJedinicaMjere.Items[cbJedinicaMjere.SelectedIndex];
            return roba;
        }

        private void fillControls()
        {
            tbxSifra.Text = roba.SifraRoba.ToString();
            tbxNaziv.Text = roba.Naziv;
            VeleprodajaUtil.initJedinicaMjereComboBox(cbJedinicaMjere, roba.JedinicaMjere.SifraJediniceMjere);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (roba == null)
            {
                roba = fillObject();
                int rows = VeleprodajaUtil.getDAOFactory().getRobaDAO().insert(roba);
                lblUspjesnoSacuvana.Visible = true;
                if (rows > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                int staraSifra = roba.SifraRoba;
                roba = fillObject();
                int rows = VeleprodajaUtil.getDAOFactory().getRobaDAO().update(roba,staraSifra);
                lblUspjesnoSacuvana.Visible = true;
                if (rows > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
