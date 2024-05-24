using AthleteTrackLogic.Classes;
using AthleteTrackLogic.Interfaces;
using Microsoft.Data.SqlClient;

namespace AthleteTrackDAL
{
    public class Schema_sDAL : ISchemasDAL
    {
        string connectionString = "Server=mssqlstud.fhict.local;Database=dbi536130_athletet;User Id=dbi536130_athletet;Password=123;TrustServerCertificate=True;";

        public List<SearchResult> GetSchemas(string naam)
        {
            List<SearchResult> results = new();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Wedstrijdschema \r\nWHERE Wedstrijdschema.Naam LIKE '%' + @name + '%';");
            cmd.Connection = new SqlConnection(connectionString);
            cmd.Parameters.AddWithValue("@name", naam);
            cmd.Connection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    SearchResult.SearchType searchType = searchType = SearchResult.SearchType.Trainingsschema; ;
                    searchType = SearchResult.SearchType.Wedstrijdschema;
                    SearchResult item = new(reader.GetString(1), reader.GetInt32(0), searchType);
                    results.Add(item);
                }
            }
            cmd.Connection.Close();

            cmd = new SqlCommand("SELECT * FROM Trainingsschema \r\nWHERE Trainingsschema.Naam LIKE '%' + @name + '%';");
            cmd.Connection = new SqlConnection(connectionString);
            cmd.Parameters.AddWithValue("@name", naam);
            cmd.Connection.Open();
            using (SqlDataReader newreader = cmd.ExecuteReader())
            {
                while (newreader.Read())
                {
                    SearchResult.SearchType searchType = searchType = SearchResult.SearchType.Trainingsschema; ;
                    searchType = SearchResult.SearchType.Trainingsschema;
                    SearchResult item = new(newreader.GetString(1), newreader.GetInt32(0), searchType);
                    results.Add(item);
                }
            }
            cmd.Connection.Close();
            return results;
        }
    }
}
