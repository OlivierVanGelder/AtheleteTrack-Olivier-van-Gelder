using AthleteTrack.Models;
using Microsoft.Data.SqlClient;
using System.Data.Common;
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

        public List<SearchResultModel> GetWedstrijdschemas(string naam)
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
            wedstrijd.Onderdelen = GetOnderdelen(ID);
            return wedstrijd;
        }

        private List<OnderdeelModel> GetOnderdelen(int ID)
        {
            List<OnderdeelModel> onderdelen = new();
           
            SqlCommand cmd = new SqlCommand($"SELECT Wedstrijdschema.ID, WedstrijdschemaOnderdeel.Begintijd, WedstrijdschemaOnderdeel.Tijdsduur, Onderdeel.Naam, Onderdeel.Regelgeving, WedstrijdschemaOnderdeel.ID\r\nFROM Wedstrijdschema\r\nINNER JOIN WedstrijdschemaOnderdeel ON WedstrijdschemaOnderdeel.Wedstrijdschema_ID = Wedstrijdschema.ID\r\nINNER JOIN Onderdeel ON WedstrijdschemaOnderdeel.Onderdeel_ID = Onderdeel.ID\r\nWHERE Wedstrijdschema_ID = {ID}", s);
            using SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                OnderdeelModel o = new(reader.GetInt32(0),reader.GetString(3), ((TimeSpan)reader.GetValue(1)).ToString(@"hh\:mm"), ((TimeSpan)reader.GetValue(2)).ToString(@"hh\:mm"), reader.GetString(4), reader.GetInt32(5));
                onderdelen.Add(o);
            }
            return onderdelen;
        }

        public List<Atleet> GetAtleet(int ID)
        {
            List<Atleet> atleten = new();

            SqlCommand cmd = new SqlCommand($"SELECT Atleet.Naam \r\nFROM WedstrijdschemaOnderdeel\r\nINNER JOIN WedstrijdschemaOnderdeelAtleet ON WedstrijdschemaOnderdeelAtleet.WedstrijdschemaOnderdeel_ID = WedstrijdschemaOnderdeel.ID\r\nINNER JOIN Atleet ON WedstrijdschemaOnderdeelAtleet.Atleet_ID = Atleet.ID\r\nWHERE WedstrijdschemaOnderdeel.ID = {ID}", s);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Atleet a = new(reader.GetString(0));
                atleten.Add(a);
            }

            return atleten;
        }
    }
}
