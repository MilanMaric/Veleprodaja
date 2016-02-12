using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veleprodaja.data.dao
{
    public abstract class DAOFactory
    {
        public abstract PartnerDAO getPartnerDAO();
        public abstract RobaDAO getRobaDAO();
        public abstract JedinicaMjereDAO getJedinicaMjereDAO();
        public abstract MjestoDAO getMjestoDAO();
    }
}
