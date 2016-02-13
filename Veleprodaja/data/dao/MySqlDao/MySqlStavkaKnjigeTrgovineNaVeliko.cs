using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veleprodaja.data.dto;

namespace Veleprodaja.data.dao.MySqlDao
{
    public class MySqlStavkaKnjigeTrgovineNaVeliko : StavkaKnjigeTrgovineNaVelikoDAO
    {
        private string qInsert = "INSERT INTO `veleprodaja`.`stavka_knjige_trgovine_na_veliko` (`PoslovnaGodina`, `JIB`, `Datum`) VALUES (?poslovnaGodina, ?jib, ?datum);";

        public static StavkaKnjigeTrgovineNaVelikoDTO readerToStavkaKnjigeTrgovineNaVeliko(MySqlDataReader reader)
        {
            StavkaKnjigeTrgovineNaVelikoDTO stavka = new StavkaKnjigeTrgovineNaVelikoDTO();
            stavka.RedniBroj = reader.GetInt32("RedniBroj");
            stavka.PoslovnaGodina = reader.GetInt32("PoslovnaGodina");
            stavka.Datum = reader.GetDateTime("Datum");
            return stavka;
        }

        public int insert(StavkaKnjigeTrgovineNaVelikoDTO stavka)
        {
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = qInsert;
            command.Parameters.AddWithValue("poslovnaGodina", stavka.PoslovnaGodina);
            command.Parameters.AddWithValue("jib", stavka.Partner.Jib);
            command.Parameters.AddWithValue("datum", stavka.Datum);
            int rows=command.ExecuteNonQuery();
            if (rows > 0)
            {
                stavka.RedniBroj =(int) command.LastInsertedId;
            }
            return rows;
        }
    }
}
