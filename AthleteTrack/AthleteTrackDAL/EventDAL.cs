﻿using AthleteTrackDAL.DTO_s;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthleteTrackDAL
{
    public class EventDAL
    {
        string connectionString = "Server=mssqlstud.fhict.local;Database=dbi536130_athletet;User Id=dbi536130_athletet;Password=123;TrustServerCertificate=True;";

        public EventDTO GetEventDetails(int ID)
        {
            EventDTO @event = new();
            SqlCommand cmd = new();

            cmd.CommandText =
                "SELECT * FROM Wedstrijdschema WHERE ID = @id";
            cmd.Parameters.AddWithValue("@id", ID);
            cmd.Connection = new SqlConnection(connectionString);
            cmd.Connection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                foreach (DbDataRecord record in reader)
                {
                    @event.ID = record.GetInt32(0);
                    @event.Name = record.GetString(1);
                    @event.StartTime = ((TimeSpan)record.GetValue(2)).ToString(@"hh\:mm");
                    @event.EndTime = ((TimeSpan)record.GetValue(3)).ToString(@"hh\:mm");
                    @event.Date = record.GetDateTime(4).ToShortDateString().ToString();
                }
            }
            cmd.Connection.Close();
            DisciplinesDAL disciplinesDAL = new();
            @event.Disciplines = disciplinesDAL.GetDisciplines(ID);
            return @event;
        }

        public void AddEvent(EventDTO @event)
        {
            SqlConnection conn = new(connectionString);
            conn.Open();
            SqlCommand cmd = new(
                "INSERT INTO Wedstrijdschema (Naam, Begintijd, Eindtijd, Datum)" +
                "VALUES ('@name', '@starttime', '@endtime', '@date');", conn);
            cmd.Parameters.AddWithValue("@date", @event.Date);
            cmd.Parameters.AddWithValue("@name", @event.Name);
            cmd.Parameters.AddWithValue("@starttime", @event.StartTime);
            cmd.Parameters.AddWithValue("@endtime", @event.EndTime);
            cmd.ExecuteNonQuery();
            foreach (DisciplineDTO discipline in @event.Disciplines)
            {
                SqlCommand disciplineCmd = new("", conn);
            }
            conn.Close();
        }

        public void _AddEvent(EventDTO @event)
        {
            SqlCommand cmd = new();

            cmd.CommandText =
                "INSERT INTO Wedstrijdschema (Naam, Begintijd, Eindtijd, Datum)" +
                "VALUES ('@name', '@starttime', '@endtime', '@date');";
            cmd.Parameters.AddWithValue("@date", @event.Date);
            cmd.Parameters.AddWithValue("@name", @event.Name);
            cmd.Parameters.AddWithValue("@starttime", @event.StartTime);
            cmd.Parameters.AddWithValue("@endtime", @event.EndTime);
            cmd.Connection = new SqlConnection(connectionString);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            foreach (DisciplineDTO discipline in @event.Disciplines)
            {

            }

            cmd.Connection.Close();
        }
    }
}
