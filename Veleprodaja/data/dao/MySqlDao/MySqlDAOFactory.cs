using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veleprodaja.data.dao.MySqlDao
{
    public class MySqlDAOFactory : DAOFactory
    {
        override public PartnerDAO getPartnerDAO()
        {
            return new MySqlPartnerDAO();
        }

        override public RobaDAO getRobaDAO()
        {
            return new MySqlRobaDAO();
        }

        public override JedinicaMjereDAO getJedinicaMjereDAO()
        {
            return new MySqlJedinicaMjereDAO();
        }

        public override MjestoDAO getMjestoDAO()
        {
            return new MySqlMjestoDAO();
        }
        public override KalkulacijaDAO getKalkulacijaDAO()
        {
            return new MySqlKalkulacijaDAO();
        }

        public override StavkaKalkulacijeDAO getStavkaKalkulacijeDAO()
        {
            return new MySqlStavkaKalkulacijeDAO();
        }

        public override OtpremnicaDAO getOtpremnicaDAO()
        {
            return new MySqlOtpremnicaDAO();
        }

        public override StavkaOtpremniceDAO getStavkaOtpremniceDAO()
        {
            return new MySqlStavkaOtpremniceDAO();
        }
    }
}
