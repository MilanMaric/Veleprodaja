using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veleprodaja.data.dto
{
    public class ZiroRacunDTO
    {
        private int brojZiroRacuna;

        public int BrojZiroRacuna
        {
            get { return brojZiroRacuna; }
            set { brojZiroRacuna = value; }
        }
        private BankaDTO banka;

        internal BankaDTO Banka
        {
            get { return banka; }
            set { banka = value; }
        }
        private PartnerDTO partner;

        public PartnerDTO Partner
        {
            get { return partner; }
            set { partner = value; }
        }
    }
}
