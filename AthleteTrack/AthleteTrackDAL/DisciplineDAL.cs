using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AthleteTrackLogic.Interfaces;
using AthleteTrackLogic.Classes;
using Microsoft.Data.SqlClient;

namespace AthleteTrackDAL
{
    public class DisciplineDAL : IDisciplineDAL
    {
        public List<Discipline> GetDiscipline(int ID)
        {
            List<Discipline> onderdelen = new();

            SqlCommand cmd = new SqlCommand($"SELECT Wedstrijdschema.ID, WedstrijdschemaOnderdeel.Begintijd, WedstrijdschemaOnderdeel.Tijdsduur, Onderdeel.Naam, Onderdeel.Regelgeving, WedstrijdschemaOnderdeel.ID\r\nFROM Wedstrijdschema\r\nINNER JOIN WedstrijdschemaOnderdeel ON WedstrijdschemaOnderdeel.Wedstrijdschema_ID = Wedstrijdschema.ID\r\nINNER JOIN Onderdeel ON WedstrijdschemaOnderdeel.Onderdeel_ID = Onderdeel.ID\r\nWHERE Wedstrijdschema_ID = {ID}", s);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Discipline o = new(reader.GetInt32(0), reader.GetString(3), ((TimeSpan)reader.GetValue(1)).ToString(@"hh\:mm"), ((TimeSpan)reader.GetValue(2)).ToString(@"hh\:mm"), reader.GetString(4), reader.GetInt32(5));
                onderdelen.Add(o);
            }
            return onderdelen;
        }

        public List<Discipline> GetDisciplines()
        {
            List<Discipline> onderdelen = new();

            SqlCommand cmd = new SqlCommand($"SELECT Onderdeel.Naam, Onderdeel.ID \r\nFROM Onderdeel", s);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Discipline o = new(reader.GetInt32(1), reader.GetString(0), "00:00", "00:00", " ", 0);
                onderdelen.Add(o);
            }
            return onderdelen;
        }
    }
}
