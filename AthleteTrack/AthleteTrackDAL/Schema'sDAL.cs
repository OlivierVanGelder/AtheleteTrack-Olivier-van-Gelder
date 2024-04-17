using AthleteTrackDAL.DTO_s;
using Microsoft.Data.SqlClient;

namespace AthleteTrackDAL
{
    public class Schema_sDAL
    {
        string connectionString = "Server=mssqlstud.fhict.local;Database=dbi536130_athletet;User Id=dbi536130_athletet;Password=123;TrustServerCertificate=True;";

        public List<SearchResultDTO> GetSchemas(string naam)
        {
            List<SearchResultDTO> results = new();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Wedstrijdschema \r\nWHERE Wedstrijdschema.Naam LIKE '%' + @name + '%';");
            cmd.Connection = new SqlConnection(connectionString);
            cmd.Parameters.AddWithValue("@name", naam);
            cmd.Connection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    SearchResultDTO.SearchType searchType = searchType = SearchResultDTO.SearchType.Trainingsschema; ;
                    searchType = SearchResultDTO.SearchType.Wedstrijdschema;
                    SearchResultDTO item = new(searchType);
                    item.Name = reader.GetString(1);
                    item.ID = reader.GetInt32(0);
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
                    SearchResultDTO.SearchType searchType = searchType = SearchResultDTO.SearchType.Trainingsschema; ;
                    searchType = SearchResultDTO.SearchType.Trainingsschema;
                    SearchResultDTO item = new(searchType);
                    item.Name = newreader.GetString(1);
                    item.ID = newreader.GetInt32(0);
                    results.Add(item);
                }
            }
            cmd.Connection.Close();
            return results;
        }
    }
}
