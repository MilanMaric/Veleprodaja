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
    public partial class RobaPregledForm : PregledForm
    {
        public RobaPregledForm()
        {
            InitializeComponent();
            initRobaKolone();
            splitContainer1.Panel2Collapsed = true;
            popuniSveRobe();
            sifarnikRobeToolStripMenuItem.Enabled = false;
            this.dodavanjeRobeToolStripMenuItem.Click += new System.EventHandler(this.dodavanjeRobeClick);
        }

        private void dodavanjeRobeClick(object sender, EventArgs e)
        {
            popuniSveRobe();
        }

        private void initRobaKolone()
        {
            DataGridViewColumn col = new DataGridViewTextBoxColumn();
            col.Name = "colSifra";
            col.HeaderText = "Sifra robe";
            col.FillWeight = 50;
            dgPregled.Columns.Add(col);
            col = new DataGridViewTextBoxColumn();
            col.Name = "colNaziv";
            col.HeaderText = "Naziv robe";
            col.ToolTipText = "Naziv robe";
            col.FillWeight = 150;
            dgPregled.Columns.Add(col);
            col = new DataGridViewTextBoxColumn();
            col.Name = "colJedinicaMjere";
            col.HeaderText = "Jedinica mjere";
            col.FillWeight = 80;
            dgPregled.Columns.Add(col);
        }

        private void objectToRow(RobaDTO roba)
        {
            dgPregled.Rows.Add(new object[] { roba.SifraRoba, roba.Naziv, roba.JedinicaMjere.OpisJediniceMjere });
        }

        private void popuniSveRobe()
        {
            dgPregled.Rows.Clear();
            List<RobaDTO> lista = VeleprodajaUtil.getDAOFactory().getRobaDAO().getAll();
            foreach (RobaDTO roba in lista)
            {
                objectToRow(roba);
            }
        }
    }
}
