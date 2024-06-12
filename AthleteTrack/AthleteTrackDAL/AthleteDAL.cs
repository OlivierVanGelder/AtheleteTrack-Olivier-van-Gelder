using AthleteTrackLogic.Classes;
using AthleteTrackLogic.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthleteTrackDAL
{
    public class AthleteDAL : IAthleteDAL
    {
        string connectionString = "Server=mssqlstud.fhict.local;Database=dbi536130_athletet;User Id=dbi536130_athletet;Password=123;TrustServerCertificate=True;";

        public List<Athlete> GetAtleten(int ID)
        {
            List<Athlete> atleten = new();
            SqlCommand cmd = new();

            cmd.CommandText =
                "SELECT Atleet.Naam, Atleet.ID " +
                "FROM WedstrijdschemaOnderdeel " +
                "INNER JOIN WedstrijdschemaOnderdeelAtleet ON WedstrijdschemaOnderdeelAtleet.WedstrijdschemaOnderdeel_ID = WedstrijdschemaOnderdeel.ID " +
                "INNER JOIN Atleet ON WedstrijdschemaOnderdeelAtleet.Atleet_ID = Atleet.ID " +
                "WHERE WedstrijdschemaOnderdeel.ID = @id";
            cmd.Parameters.AddWithValue("@id", ID);
            cmd.Connection = new SqlConnection(connectionString);
            cmd.Connection.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Athlete atleet = new();
                atleet.Name = reader["Naam"].ToString()!;
                atleet.ID = Convert.ToInt32(reader["ID"]);
                atleten.Add(atleet);
            }
            cmd.Connection.Close();
            return atleten;
        }
    }
}
