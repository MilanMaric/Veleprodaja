using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Veleprodaja.data.dto;

namespace Veleprodaja.data.dao.MySqlDao
{
    public class MySqlPartnerDAO : PartnerDAO
    {
        private string qGetAll = "select * from partner p inner join mjesto m on p.PostanskiBroj=m.PostanskiBroj;";
        private string qInsert = "INSERT INTO `veleprodaja`.`partner` (`JIB`, `Naziv`, `Adresa`, `PostanskiBroj`) VALUES (?jib, ?naziv, ?adresa, ?postanskiBroj);";
        public List<PartnerDTO> getAll()
        {
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = qGetAll;
            List<PartnerDTO> lista = new List<PartnerDTO>();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                PartnerDTO partner = readerToPartnerDTO(reader);
                partner.Mjesto = MySqlMjestoDAO.readerToMjestoDTO(reader);
                lista.Add(partner);
            }
            return lista;
        }

        public int insert(PartnerDTO partner)
        {
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = qInsert;
            command.Parameters.AddWithValue("jib", partner.Jib);
            command.Parameters.AddWithValue("naziv", partner.Naziv);
            command.Parameters.AddWithValue("adresa", partner.Adresa);
            command.Parameters.AddWithValue("postanskiBroj", partner.Mjesto.PostanskiBroj);
            int rows=command.ExecuteNonQuery();
            ConnectionPool.checkInConnection(connection);
            return rows;
        }

        public int update(PartnerDTO partner)
        {
            return 1;
        }

        public static PartnerDTO readerToPartnerDTO(MySqlDataReader reader)
        {
            PartnerDTO partner = new PartnerDTO();
            partner.Jib = reader.GetString("JIB");
            partner.Adresa = reader["Adresa"].ToString();
            partner.Naziv = reader["Naziv"].ToString();
            return partner;
        }
    }
}
