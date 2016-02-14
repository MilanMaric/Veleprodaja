using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veleprodaja.data.dto
{
    public class RobaDTO
    {
        private int sifraRoba;

        public int SifraRoba
        {
            get { return sifraRoba; }
            set { sifraRoba = value; }
        }
        private string naziv;

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }
        private JedinicaMjereDTO jedinicaMjere;

        public JedinicaMjereDTO JedinicaMjere
        {
            get { return jedinicaMjere; }
            set { jedinicaMjere = value; }
        }

        private double raspolozivaKolicina;

        public double RaspolozivaKolicina
        {
            get { return raspolozivaKolicina; }
            set { raspolozivaKolicina = value; }
        }

        private double poslednjaCijena;

        public double PoslednjaCijena
        {
            get { return poslednjaCijena; }
            set { poslednjaCijena = value; }
        }
    }
}
