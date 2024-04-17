﻿using AthleteTrackDAL.DTO_s;
using Microsoft.Data.SqlClient;

namespace AthleteTrackDAL
{
    public class DisciplinesDAL
    {
        string connectionString = "Server=mssqlstud.fhict.local;Database=dbi536130_athletet;User Id=dbi536130_athletet;Password=123;TrustServerCertificate=True;";

        public List<DisciplineDTO> GetDisciplines(int ID)
        {
            List<DisciplineDTO> disciplines = new();

            SqlCommand cmd = new();

            cmd.CommandText =
                "SELECT Wedstrijdschema.ID, WedstrijdschemaOnderdeel.Begintijd, WedstrijdschemaOnderdeel.Tijdsduur, Onderdeel.Naam, Onderdeel.Regelgeving, WedstrijdschemaOnderdeel.ID " +
                "FROM Wedstrijdschema " +
                "INNER JOIN WedstrijdschemaOnderdeel ON WedstrijdschemaOnderdeel.Wedstrijdschema_ID = Wedstrijdschema.ID " +
                "INNER JOIN Onderdeel ON WedstrijdschemaOnderdeel.Onderdeel_ID = Onderdeel.ID " +
                "WHERE Wedstrijdschema_ID = @id";
            cmd.Parameters.AddWithValue("@id", ID);
            cmd.Connection = new SqlConnection(connectionString);
            cmd.Connection.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DisciplineDTO o = new();
                o.StartTime = ((TimeSpan)reader.GetValue(1)).ToString(@"hh\:mm");
                o.Rules = reader.GetString(4);
                o.Time = ((TimeSpan)reader.GetValue(2)).ToString(@"hh\:mm");
                o.DisciplineID = reader.GetInt32(5);
                o.Name = reader.GetString(3);
                o.ID = reader.GetInt32(0);

                disciplines.Add(o);
            }
            cmd.Connection.Close();
            return disciplines;
        }

        public List<DisciplineDTO> GetAllDisciplines()
        {
            List<DisciplineDTO> disciplines = new();

            SqlCommand cmd = new();

            cmd.CommandText =
                "SELECT [ID], [Naam], [Regelgeving] " +
                "FROM [dbi536130_athletet].[dbo].[Onderdeel] ";
            cmd.Connection = new SqlConnection(connectionString);
            cmd.Connection.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DisciplineDTO o = new();
                o.StartTime = "";
                o.Rules = reader.GetString(2);
                o.Time = "";
                o.DisciplineID = 1;
                o.Name = reader.GetString(1);
                o.ID = reader.GetInt32(0);

                disciplines.Add(o);
            }
            cmd.Connection.Close();
            return disciplines;
        }
    }
}
