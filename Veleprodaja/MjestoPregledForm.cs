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
    public partial class MjestoPregledForm : PregledForm
    {
        public MjestoPregledForm()
        {
            InitializeComponent();
            initMjestoKolone();
            splitContainer1.Panel2Collapsed = true;
            popuniSvaMjesta();
            dodavanjeNovogMjestaToolStripMenuItem.Click += new EventHandler(dodavanjeNovogMjestaClick);
            pregledSvihMjestaToolStripMenuItem.Enabled = false;
        }

        private void dodavanjeNovogMjestaClick(object sender, EventArgs e)
        {
            popuniSvaMjesta();
        }

        private void initMjestoKolone()
        {
            dgPregled.Columns.Clear();
            DataGridViewColumn col = new DataGridViewTextBoxColumn();
            col.Name = "colPostanskiBroj";
            col.HeaderText = "Postanski broj";
            col.FillWeight = 50;
            dgPregled.Columns.Add(col);
            col = new DataGridViewTextBoxColumn();
            col.Name = "colNaziv";
            col.HeaderText = "Naziv";
            col.FillWeight = 200;
            dgPregled.Columns.Add(col);
        }

        private void objectToRow(MjestoDTO mjesto)
        {
            dgPregled.Rows.Add(new object[] { mjesto.PostanskiBroj,mjesto.Naziv });
        }

        private void popuniSvaMjesta()
        {
            dgPregled.Rows.Clear();
            List<MjestoDTO> lista = VeleprodajaUtil.getDAOFactory().getMjestoDAO().getAll();
            foreach (MjestoDTO mjesto in lista)
            {
                objectToRow(mjesto);
            }
        }
    }
}
