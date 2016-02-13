using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veleprodaja.data.dto;

namespace Veleprodaja.data.dao.MySqlDao
{
    public class MySqlMjestoDAO:MjestoDAO
    {
        private string qGetAll = "select * from mjesto";
        private string qInsert = "INSERT INTO `veleprodaja`.`mjesto` (`PostanskiBroj`, `naziv`) VALUES (?postanskiBroj, ?naziv);";
        public List<MjestoDTO> getAll()
        {
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = qGetAll;
            MySqlDataReader reader = command.ExecuteReader();
            List<MjestoDTO> lista = new List<MjestoDTO>();
            while (reader.Read())
            {
                lista.Add(readerToMjestoDTO(reader));
            }
            reader.Close();
            ConnectionPool.checkInConnection(connection);
            return lista;
        }

        public static MjestoDTO readerToMjestoDTO(MySqlDataReader reader)
        {
            MjestoDTO mjesto = new MjestoDTO();
           
                mjesto.Naziv = reader["NazivMjesto"].ToString();
            mjesto.PostanskiBroj = reader.GetInt32("PostanskiBroj") ;
            return mjesto;
        }

        public int insert(MjestoDTO mjesto)
        {
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = qInsert;
            command.Parameters.AddWithValue("postanskiBroj", mjesto.PostanskiBroj);
            command.Parameters.AddWithValue("naziv", mjesto.Naziv);
            int rows=command.ExecuteNonQuery();
            ConnectionPool.checkInConnection(connection);
            return rows;
        }
    }
}
