using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veleprodaja.data.dto;

namespace Veleprodaja.data.dao.MySqlDao
{
    public class MySqlStavkaKnjigeTrgovineNaVeliko 
    {
        public static StavkaKnjigeTrgovineNaVelikoDTO readerToStavkaKnjigeTrgovineNaVeliko(MySqlDataReader reader)
        {
            StavkaKnjigeTrgovineNaVelikoDTO stavka = new StavkaKnjigeTrgovineNaVelikoDTO();
            stavka.RedniBroj = reader.GetInt32("RedniBroj");
            stavka.PoslovnaGodina = reader.GetInt32("PoslovnaGodina");
            stavka.Datum = reader.GetDateTime("Datum");
            return stavka;
        }
    }
}
