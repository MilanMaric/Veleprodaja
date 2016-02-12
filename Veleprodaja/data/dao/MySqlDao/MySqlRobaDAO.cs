using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veleprodaja.data.dto;

namespace Veleprodaja.data.dao.MySqlDao
{
    public class MySqlRobaDAO:RobaDAO
    {
        private string qGetAll = "select * from roba_sa_jedinicom_mjere;";
        private string qInsert = "INSERT INTO `veleprodaja`.`roba` (`SifraRoba`, `Naziv`, `SifraJediniceMjere`) VALUES (?sifra, ?naziv, ?jm);";

        public List<RobaDTO> getAll()
        {
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = qGetAll;
            MySqlDataReader reader = command.ExecuteReader();
            List<RobaDTO> lista = new List<RobaDTO>();
            while (reader.Read())
            {
                RobaDTO roba = readerToRobaDTO(reader);
                roba.JedinicaMjere = MySqlJedinicaMjereDAO.readerToJedinicaMjereDTO(reader);
                lista.Add(roba);
            }
            reader.Close();
            ConnectionPool.checkInConnection(connection);
            return lista;
        }

        public int insert(RobaDTO roba)
        {
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = qInsert;
            command.Parameters.AddWithValue("sifra", roba.SifraRoba);
            command.Parameters.AddWithValue("naziv", roba.Naziv);
            command.Parameters.AddWithValue("jm", roba.JedinicaMjere.SifraJediniceMjere);
            int id=command.ExecuteNonQuery();
            ConnectionPool.checkInConnection(connection);
            return id;
        }

        public static RobaDTO readerToRobaDTO(MySqlDataReader reader)
        {
            RobaDTO roba = new RobaDTO();
            roba.SifraRoba = reader.GetInt32("SifraRoba");
            roba.Naziv = reader.GetString("Naziv");
            return roba;
        }
    }
}
