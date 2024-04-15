using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AthleteTrackLogic.Interfaces;
using AthleteTrackLogic.Classes;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace AthleteTrackDAL
{
    public class WedstrijdDAL : IWedstrijdDAL
    {
       
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

        public Wedstrijd GetWedstrijdDetails(int ID)
        {
            Wedstrijd wedstrijd = new();

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
            DisciplineDAL dD = new DisciplineDAL();
            wedstrijd.Onderdelen = dD.GetDiscipline(ID);
            return wedstrijd;
        }
    }
}
