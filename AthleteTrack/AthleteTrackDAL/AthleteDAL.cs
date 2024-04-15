using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AthleteTrackLogic.Classes;
using AthleteTrackLogic.Interfaces;
using Microsoft.Data.SqlClient;
using AthleteTrackLogic.Classes;

namespace AthleteTrackDAL
{
    public class AthleteDAL : IAthleteDAL
    {
        public List<Athlete> GetAtleet(int ID)
        {
            List<Athlete> atleten = new();

            SqlCommand cmd = new SqlCommand($"SELECT Atleet.Naam \r\nFROM WedstrijdschemaOnderdeel\r\nINNER JOIN WedstrijdschemaOnderdeelAtleet ON WedstrijdschemaOnderdeelAtleet.WedstrijdschemaOnderdeel_ID = WedstrijdschemaOnderdeel.ID\r\nINNER JOIN Atleet ON WedstrijdschemaOnderdeelAtleet.Atleet_ID = Atleet.ID\r\nWHERE WedstrijdschemaOnderdeel.ID = {ID}", s);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Athlete a = new(reader.GetString(0));
                atleten.Add(a);
            }

            return atleten;
        }
    }
}
