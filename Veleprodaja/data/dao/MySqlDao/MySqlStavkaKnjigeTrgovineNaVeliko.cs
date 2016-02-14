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
        private string qUpdate = "UPDATE `veleprodaja`.`stavka_knjige_trgovine_na_veliko` SET Datum=?datum,JIB=?jib WHERE `RedniBroj`=?RedniBroj;";
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

        public int update(StavkaKnjigeTrgovineNaVelikoDTO stavka)
        {
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = qUpdate;
            command.Parameters.AddWithValue("RedniBroj", stavka.RedniBroj);
            command.Parameters.AddWithValue("jib", stavka.Partner.Jib);
            command.Parameters.AddWithValue("datum", stavka.Datum);
            int rows1 = command.ExecuteNonQuery();
            ConnectionPool.checkInConnection(connection);
            return rows1;
        }
    }
}
