using AthleteTrack.Models;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Reflection;

namespace AthleteTrackDAL
{
    public class Dataconnection
    {
        private const string connectionstring = "Server=mssqlstud.fhict.local;Database=dbi536130_athletet;User Id=dbi536130_athletet;Password=123;TrustServerCertificate=True;";
        SqlConnection s = new SqlConnection(connectionstring);

        public Dataconnection()
        {
            s.Open();
        }
        ~Dataconnection()
        {
            s.Close();
        }

        public List<SearchResultModel> GetSchemas(string naam)
        {
            List<SearchResultModel> results = new();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Wedstrijdschema \r\nWHERE Wedstrijdschema.Naam LIKE '%' + @name + '%';", s);
            cmd.Parameters.AddWithValue("@name", naam);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    SearchResultModel.SearchType searchType = new();
                    searchType = SearchResultModel.SearchType.Wedstrijdschema;
                    SearchResultModel item = new(reader.GetString(1), reader.GetInt32(0), searchType);
                    results.Add(item);
                }
            }

            cmd = new SqlCommand("SELECT * FROM Trainingsschema \r\nWHERE Trainingsschema.Naam LIKE '%' + @name + '%';", s);
            cmd.Parameters.AddWithValue("@name", naam);
            using (SqlDataReader newreader = cmd.ExecuteReader())
            {
                while (newreader.Read())
                {
                    SearchResultModel.SearchType searchType = new();
                    searchType = SearchResultModel.SearchType.Trainingsschema;
                    SearchResultModel item = new(newreader.GetString(1), newreader.GetInt32(0), searchType);
                    results.Add(item);
                }
            }
            return results;
        }

        public WedstrijdPageModel GetWedstrijdDetails(int ID)
        {
            WedstrijdPageModel wedstrijd = new();

            SqlCommand cmd = new SqlCommand($"SELECT * FROM Wedstrijdschema WHERE ID = {ID}", s);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                foreach (DbDataRecord record in reader)
                {
                    wedstrijd.ID = record.GetInt32(0);
                    wedstrijd.Name = record.GetString(1);
                    wedstrijd.Begintijd = ((TimeSpan)record.GetValue(2)).ToString(@"hh\:mm");
                    wedstrijd.Eindtijd = ((TimeSpan)record.GetValue(3)).ToString(@"hh\:mm");
                    wedstrijd.Datum = record.GetDateTime(4).ToShortDateString().ToString();
                }
            }
            AtleetDAL atleetDAL = new AtleetDAL();
            wedstrijd.Onderdelen = atleetDAL.GetAtleten(ID);
            return wedstrijd;
        }

        public TrainingsPageModel GetTrainingsDetails(int ID)
        {
            TrainingsPageModel training = new();

            SqlCommand cmd = new SqlCommand($"SELECT * FROM Trainingsschema WHERE ID = {ID}", s);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                foreach (DbDataRecord record in reader)
                {
                    training.ID = record.GetInt32(0);
                    training.Name = record.GetString(1);
                    training.StartTime = ((TimeSpan)record.GetValue(2)).ToString(@"hh\:mm");
                    training.EndTime = ((TimeSpan)record.GetValue(3)).ToString(@"hh\:mm");
                }
            }
            training.Exercises = GetExercises(ID);
            return training;
        }   
    }
}
