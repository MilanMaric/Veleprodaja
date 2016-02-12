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
    public partial class PartnerPregledForm : PregledForm
    {
        public PartnerPregledForm()
        {
            InitializeComponent();
            initPartnerKolone();
            fillAllPartners();
            splitContainer1.Panel2Collapsed = true;
            dodavanjeNovogPartneraToolStripMenuItem.Click += new EventHandler(dodavanjeParneraClick);
            pregledSvihPartneraToolStripMenuItem.Enabled = false;
        }

        private void dodavanjeParneraClick(object sender, EventArgs e)
        {
            fillAllPartners();
        }

        private void initPartnerKolone()
        {
            DataGridViewColumn col = new DataGridViewTextBoxColumn();
            col.Name = "colJIB";
            col.HeaderText = "JIB";
            col.ToolTipText = "Jedinstveni indentifikacioni broj partnera";
            col.FillWeight = 50;
            dgPregled.Columns.Add(col);
            col = new DataGridViewTextBoxColumn();
            col.Name = "colNaziv";
            col.HeaderText = "Naziv partnera";
            col.ToolTipText = "Naziv partnera";
            col.FillWeight = 150;
            dgPregled.Columns.Add(col);
            col = new DataGridViewTextBoxColumn();
            col.Name = "colAdresa";
            col.HeaderText = "Adresa partnera";
            col.FillWeight = 100;
            dgPregled.Columns.Add(col);
            col = new DataGridViewTextBoxColumn();
            col.Name = "colMjesto";
            col.HeaderText = "Mjesto";
            col.FillWeight = 80;
            dgPregled.Columns.Add(col);
        }

        private void partnerToRow(PartnerDTO partner)
        {
            dgPregled.Rows.Add(new object[] { partner.Jib, partner.Naziv, partner.Adresa,partner.Mjesto.Naziv});
        }

        private void fillAllPartners()
        {
            List<PartnerDTO> listaPartnera = VeleprodajaUtil.getDAOFactory().getPartnerDAO().getAll();
            foreach (PartnerDTO partner in listaPartnera)
            {
                partnerToRow(partner);
            }
        }
    }
}
