using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veleprodaja.data.dto;

namespace Veleprodaja.data.dao.MySqlDao
{
    public class MySqlJedinicaMjereDAO : JedinicaMjereDAO
    {
        private string qGetAll = "select * from jedinica_mjere;";
        public List<JedinicaMjereDTO> getAll()
        {
            MySqlConnection connection=ConnectionPool.checkOutConnection();
            MySqlCommand command=connection.CreateCommand();
            command.CommandText=qGetAll;
            MySqlDataReader reader=command.ExecuteReader();
            List<JedinicaMjereDTO> lista = new List<JedinicaMjereDTO>();
            while(reader.Read())
            {
                lista.Add(readerToJedinicaMjereDTO(reader));
            }
            reader.Close();
            ConnectionPool.checkInConnection(connection);
            return lista;
        }

        public static JedinicaMjereDTO readerToJedinicaMjereDTO(MySqlDataReader reader)
        {
            JedinicaMjereDTO jedinicaMjere = new JedinicaMjereDTO();
            jedinicaMjere.SifraJediniceMjere = reader.GetString("SifraJediniceMjere");
            jedinicaMjere.OpisJediniceMjere = reader.GetString("OpisJediniceMjere");
            return jedinicaMjere;
        }
    }
}
