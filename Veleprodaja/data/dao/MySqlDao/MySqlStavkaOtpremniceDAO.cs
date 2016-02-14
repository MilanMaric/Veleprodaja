using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veleprodaja.data.dto;

namespace Veleprodaja.data.dao.MySqlDao
{
    public class MySqlStavkaOtpremniceDAO :StavkaOtpremniceDAO 
    {
        private string qGetByKalkulacija = "select * from stavka_otpremnica_view_detaljno where RedniBroj=?RedniBroj;";
        private string qInsert = "insert into stavka_otpremnice (SifraRoba,Kolicina,VeleprodajnaCijena,Rabat) values (?SifraRoba,?Kolicina,?VeleprodajnaCijena,?Rabat);";

        public List<StavkaOtpremniceDTO> getByOtpremnica(OtpremnicaDTO otpremnica)
        {
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = qGetByKalkulacija;
            command.Parameters.AddWithValue("RedniBroj", otpremnica.RedniBroj);
            MySqlDataReader reader = command.ExecuteReader();
            List<StavkaOtpremniceDTO> lista = new List<StavkaOtpremniceDTO>();
            while (reader.Read())
            {
                StavkaOtpremniceDTO stavka = readerToStavkaOtpremniceDTO(reader);
                stavka.Otpremnica = otpremnica;
                stavka.Roba = MySqlRobaDAO.readerToRobaDTO(reader);
                stavka.Roba.JedinicaMjere = MySqlJedinicaMjereDAO.readerToJedinicaMjereDTO(reader);
                lista.Add(stavka);
            }
            reader.Close();
            ConnectionPool.checkInConnection(connection);
            return lista;

        }

        public static  StavkaOtpremniceDTO readerToStavkaOtpremniceDTO(MySqlDataReader reader)
        {
            StavkaOtpremniceDTO stavka = new StavkaOtpremniceDTO();
            stavka.Kolicina = reader.GetDouble("Kolicina");
            stavka.VeleprodajnaCijena = reader.GetDouble("VeleprodajnaCijena");
            stavka.Rabat = reader.GetDouble("Rabat");
            stavka.CijenaSaRabatom = reader.GetDouble("CijenaSaRabatom");
            stavka.IznosSaRabatom = reader.GetDouble("IznosSaRabatom");
            stavka.VeleprodajniIznos = reader.GetDouble("VeleprodajniIznos");
            return stavka;
        }

        public int insert(StavkaOtpremniceDTO stavka)
        {
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = qInsert;
            command.Parameters.AddWithValue("RedniBroj", stavka.Otpremnica.RedniBroj);
            command.Parameters.AddWithValue("SifraRoba", stavka.Roba.SifraRoba);
            command.Parameters.AddWithValue("Kolicina", stavka.Kolicina);
            command.Parameters.AddWithValue("Rabat", stavka.Rabat);
            command.Parameters.AddWithValue("VeleprodajnaCijena", stavka.VeleprodajnaCijena);
            int rows = command.ExecuteNonQuery();
            ConnectionPool.checkInConnection(connection);
            return rows;
        }

        public void update(StavkaOtpremniceDTO stavka, int staraSifraRobe)
        {
            throw new NotImplementedException();
        }
    }
}
