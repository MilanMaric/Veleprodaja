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
        public RobaDodajForm()
        {
            InitializeComponent();
            VeleprodajaUtil.initJedinicaMjereComboBox(cbJedinicaMjere);
        }

        private RobaDTO fillObject()
        {
            RobaDTO roba = new RobaDTO();
            roba.SifraRoba = int.Parse(tbxSifra.Text);
            roba.Naziv = tbxNaziv.Text;
            roba.JedinicaMjere =(JedinicaMjereDTO) cbJedinicaMjere.Items[cbJedinicaMjere.SelectedIndex];
            return roba;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RobaDTO roba = fillObject();
            int id=VeleprodajaUtil.getDAOFactory().getRobaDAO().insert(roba);
            lblUspjesnoSacuvana.Visible = true;
            if (id > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
