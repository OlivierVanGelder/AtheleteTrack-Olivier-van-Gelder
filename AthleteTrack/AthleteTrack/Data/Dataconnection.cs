using AthleteTrack.Models;
using Microsoft.Data.SqlClient;
using System.Reflection;

namespace AthleteTrack.Data
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

        public List<SearchResultModel> GetWedstrijdschemas()
        {
            List<SearchResultModel> results = new();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Wedstrijdschema", s);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                SearchResultModel item = new(reader.GetString(1), reader.GetInt32(0));
                results.Add(item);
            }
            return results;
        }
    }
}
