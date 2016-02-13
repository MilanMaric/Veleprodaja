using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veleprodaja.data.dao;
using Veleprodaja.data.dao.MySqlDao;
using Veleprodaja.data.dto;

namespace Veleprodaja
{
    public class VeleprodajaUtil
    {
        public static DAOFactory getDAOFactory()
        {
            return new MySqlDAOFactory();
        }

        private static int poslovnaGodina = 2016;

        public static int PoslovnaGodina
        {
            get { return VeleprodajaUtil.poslovnaGodina; }
            set { VeleprodajaUtil.poslovnaGodina = value; }
        }

        public static void initJedinicaMjereComboBox(ComboBox cb)
        {
            cb.Items.Clear();
            List<JedinicaMjereDTO> lista = VeleprodajaUtil.getDAOFactory().getJedinicaMjereDAO().getAll();
            foreach (JedinicaMjereDTO jedinica in lista)
            {
                cb.Items.Add(jedinica);
            }
        }

        public static void initMjestoComboBox(ComboBox cb)
        {
            cb.Items.Clear();
            List<MjestoDTO> lista = VeleprodajaUtil.getDAOFactory().getMjestoDAO().getAll();
            foreach (MjestoDTO mjesto in lista)
            {
                cb.Items.Add(mjesto);
            }
        }

        public static void initJedinicaMjereComboBox(ComboBox cb, string sifra)
        {
            cb.Items.Clear();
            List<JedinicaMjereDTO> lista = VeleprodajaUtil.getDAOFactory().getJedinicaMjereDAO().getAll();
            foreach (JedinicaMjereDTO jedinica in lista)
            {
                cb.Items.Add(jedinica);
                if (jedinica.SifraJediniceMjere.Equals(sifra))
                {
                    cb.SelectedIndex = cb.Items.Count - 1;
                }
            }
        }

        public static void initPartnerComboBox(ComboBox cb, int jib)
        {
            cb.Items.Clear();
            List<PartnerDTO> lista = VeleprodajaUtil.getDAOFactory().getPartnerDAO().getAll();
            foreach (PartnerDTO partner in lista)
            {
                cb.Items.Add(partner);
                if (partner.Jib == jib)
                {
                    cb.SelectedIndex = cb.Items.Count - 1;
                }
            }
        }
        
    }
}
