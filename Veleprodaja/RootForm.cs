using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veleprodaja.view_dodaj;

namespace Veleprodaja
{
    public partial class RootForm : Form
    {
        protected DodajForm otvorenaFormaZaDodavanje = null;
        protected PregledForm otvorenaFormaZaPregled = null;
        public RootForm()
        {
            InitializeComponent();
           
        }

        private void dodavanjeRobeToolStripMenuItem_Click(object sender, EventArgs e)
        {
                otvorenaFormaZaDodavanje = new RobaDodajForm();
                otvorenaFormaZaDodavanje.ShowDialog();
        }

        private void dodavanjeNovogPartneraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (otvorenaFormaZaPregled == null)
            {
                otvorenaFormaZaDodavanje = new PartnerDodajForm();
                otvorenaFormaZaDodavanje.ShowDialog();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.otvorenaFormaZaDodavanje != null)
            {
                otvorenaFormaZaDodavanje.Close();
            }
            this.Close();
        }

        private void pregledSvihPartneraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            otvorenaFormaZaPregled = new PartnerPregledForm();
            otvorenaFormaZaPregled.ShowDialog();
            otvorenaFormaZaPregled = null;
        }

        private void sifarnikRobeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            otvorenaFormaZaPregled = new RobaPregledForm();
            otvorenaFormaZaPregled.ShowDialog();
            otvorenaFormaZaPregled = null;
        }

        private void pregledSvihMjestaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            otvorenaFormaZaPregled = new MjestoPregledForm();
            otvorenaFormaZaPregled.ShowDialog();
            otvorenaFormaZaPregled = null;
        }

        private void dodavanjeNovogMjestaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            otvorenaFormaZaDodavanje = new MjestoDodajForm();
            otvorenaFormaZaDodavanje.ShowDialog();
            otvorenaFormaZaDodavanje = null;
        }

        private void novaKalkulacijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KalkulacijaDodajForm kdf = new KalkulacijaDodajForm();
            kdf.ShowDialog();
        }

        private void dodavanjeJediniceMjereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            otvorenaFormaZaDodavanje = new JedinicaMjereDodajForm();
            otvorenaFormaZaDodavanje.ShowDialog();
            otvorenaFormaZaDodavanje = null;
        }

        private void RootForm_Load(object sender, EventArgs e)
        {

        }

        private void dodaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OtpremnicaDodajForm odf = new OtpremnicaDodajForm();
            odf.ShowDialog();
        }
    }
}
