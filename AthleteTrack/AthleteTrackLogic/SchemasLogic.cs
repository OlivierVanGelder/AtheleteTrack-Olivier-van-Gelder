using AthleteTrack.Models;
using AthleteTrackDAL.DTO_s;
using AthleteTrackDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AthleteTrackLogic.Classes;

namespace AthleteTrackLogic
{
    public class SchemasLogic
    {
        public List<SearchResult> GetSchemas(string searchtext)
        {
            Schema_sDAL schemasDal = new();
            List<SearchResult> results = new();

            foreach (SearchResultDTO result in schemasDal.GetSchemas(searchtext))
            {

                if(result.searchType == SearchResultDTO.SearchType.Wedstrijdschema)
                {
                    SearchResult newResult = new(result.Name, result.ID, SearchResult.SearchType.Wedstrijdschema);
                    results.Add(newResult);
                }
                else
                {
                    SearchResult newResult = new(result.Name, result.ID, SearchResult.SearchType.Trainingsschema);
                    results.Add(newResult);
                }
            }
            return results;
        }
    }
}
