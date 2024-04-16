using AthleteTrackDAL.DTO_s;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthleteTrackDAL
{
    public class AtleetDAL
    {
        string connectionString = "Server=mssqlstud.fhict.local;Database=dbi536130_athletet;User Id=dbi536130_athletet;Password=123;TrustServerCertificate=True;";

        public List<AtleetDTO> GetAtleten(int ID)
        {
            List<AtleetDTO> atleten = new();
            SqlCommand cmd = new();

            cmd.CommandText = 
                "SELECT Atleet.Naam " +
                "FROM WedstrijdschemaOnderdeel " +
                "INNER JOIN WedstrijdschemaOnderdeelAtleet ON WedstrijdschemaOnderdeelAtleet.WedstrijdschemaOnderdeel_ID = WedstrijdschemaOnderdeel.ID " +
                "INNER JOIN Atleet ON WedstrijdschemaOnderdeelAtleet.Atleet_ID = Atleet.ID " +
                "WHERE WedstrijdschemaOnderdeel.ID = @id";
            cmd.Parameters.AddWithValue("@id", ID);
            cmd.Connection = new SqlConnection(connectionString);

            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                AtleetDTO atleet = new AtleetDTO();
                atleet.Name = reader["Naam"].ToString()!;
                atleten.Add(atleet);
            }

            return atleten;
        }
    }
}
