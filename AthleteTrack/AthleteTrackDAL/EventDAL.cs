using AthleteTrackLogic.Classes;
using AthleteTrackLogic.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Diagnostics;

namespace AthleteTrackDAL
{
    public class EventDAL : IEventDAL
    {
        string connectionString = "Server=mssqlstud.fhict.local;Database=dbi536130_athletet;User Id=dbi536130_athletet;Password=123;TrustServerCertificate=True;";

        public Event GetEventDetails(int ID)
        {
            Event @event = new();
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

        public void AddEvent(Event @event)
        {
            SqlConnection conn = new(connectionString);
            SqlTransaction transaction = conn.BeginTransaction();

            try
            {
                conn.Open();
                transaction = conn.BeginTransaction();
                SqlCommand cmd = new(
                    "INSERT INTO Wedstrijdschema (Naam, Begintijd, Eindtijd, Datum)" +
                    "VALUES (@name, @starttime, @endtime, @date);", conn);
                cmd.Parameters.AddWithValue("@date", @event.Date);
                cmd.Parameters.AddWithValue("@name", @event.Name);
                cmd.Parameters.AddWithValue("@starttime", @event.StartTime);
                cmd.Parameters.AddWithValue("@endtime", @event.EndTime);
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                SqlCommand eventIDcmd = new("SELECT TOP 1 ID FROM Wedstrijdschema ORDER BY ID DESC;", conn);
                int eventID = (int)eventIDcmd.ExecuteScalar();

                foreach (Discipline discipline in @event.Disciplines)
                {
                    SqlCommand disciplineCmd = new("INSERT INTO WedstrijdschemaOnderdeel(Wedstrijdschema_ID, Onderdeel_ID, Begintijd, Tijdsduur)" +
                        "VALUES (@eventID, @disciplineID, @starttime, @endtime);", conn);
                    disciplineCmd.Parameters.AddWithValue("@eventID", eventID);
                    disciplineCmd.Parameters.AddWithValue("@disciplineID", discipline.ID);
                    disciplineCmd.Parameters.AddWithValue("@starttime", discipline.StartTime);
                    disciplineCmd.Parameters.AddWithValue("@endtime", discipline.EndTime);
                    disciplineCmd.Transaction = transaction;
                    disciplineCmd.ExecuteNonQuery();

                    SqlCommand eventdisciplineIDcmd = new("SELECT TOP 1 ID FROM WedstrijdschemaOnderdeel ORDER BY ID DESC;", conn);
                    int eventdisciplineID = (int)eventdisciplineIDcmd.ExecuteScalar();

                    if (discipline.Athletes != null)
                    {
                        foreach (Athlete athlete in discipline.Athletes)
                        {
                            SqlCommand insertathleteCmd = new("INSERT INTO Atleet(Naam) " +
                            "VALUES(@name); ", conn);
                            insertathleteCmd.Parameters.AddWithValue("@name", athlete.Name);
                            insertathleteCmd.Transaction = transaction;
                            insertathleteCmd.ExecuteNonQuery();

                            SqlCommand athleteIDcmd = new("SELECT TOP 1 ID FROM Atleet ORDER BY ID DESC;", conn);
                            athlete.ID = (int)athleteIDcmd.ExecuteScalar();

                            SqlCommand athleteCmd = new("INSERT INTO WedstrijdschemaOnderdeelAtleet(WedstrijdschemaOnderdeel_ID, Atleet_ID)" +
                                "VALUES (@eventdisciplineID, @athleteID);", conn);
                            athleteCmd.Parameters.AddWithValue("@eventdisciplineID", eventdisciplineID);
                            athleteCmd.Parameters.AddWithValue("@athleteID", athlete.ID);
                            athleteCmd.Transaction = transaction;
                            athleteCmd.ExecuteNonQuery();
                        }
                    }
                }
                conn.Close();
                transaction.Commit(); 
            }
            catch
            {
                transaction.Rollback();
                Debug.WriteLine("Transaction rolled back");
            }
        }
    }
}
