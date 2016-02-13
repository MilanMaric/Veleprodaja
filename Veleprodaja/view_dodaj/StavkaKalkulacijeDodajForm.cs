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
    public partial class StavkaKalkulacijeDodajForm : DodajForm
    {
        private KalkulacijaDTO kalkulacija = null;
        private RobaDTO izabranaRoba = null;
        public StavkaKalkulacijeDodajForm()
        {
            InitializeComponent();
        }

        public StavkaKalkulacijeDodajForm(KalkulacijaDTO kalkulacija)
        {
            this.kalkulacija = kalkulacija;
        }

        private void tbxSifraRobe_Leave(object sender, EventArgs e)
        {
            RobaPregledForm rpf = new RobaPregledForm(tbxSifraRobe.Text);
            if(rpf.ShowDialog()==DialogResult.OK)
            {

            }

        }
    }
}
