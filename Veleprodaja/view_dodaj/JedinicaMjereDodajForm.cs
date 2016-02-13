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
    public partial class JedinicaMjereDodajForm : DodajForm
    {
        public JedinicaMjereDodajForm()
        {
            InitializeComponent();
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            JedinicaMjereDTO jedinicaMjere = new JedinicaMjereDTO();
            jedinicaMjere.SifraJediniceMjere = tbxSifra.Text;
            jedinicaMjere.OpisJediniceMjere = tbxSifra.Text;
            VeleprodajaUtil.getDAOFactory().getJedinicaMjereDAO().insert(jedinicaMjere);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
