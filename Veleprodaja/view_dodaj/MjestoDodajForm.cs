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
    public partial class MjestoDodajForm : DodajForm
    {
        public MjestoDodajForm()
        {
            InitializeComponent();
        }

        private MjestoDTO fillObject()
        {
            MjestoDTO mjesto = new MjestoDTO();
            mjesto.PostanskiBroj = int.Parse(textBox1.Text);
            mjesto.Naziv = textBox2.Text;
            return mjesto;
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            MjestoDTO mjesto = fillObject();
            VeleprodajaUtil.getDAOFactory().getMjestoDAO().insert(mjesto);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
