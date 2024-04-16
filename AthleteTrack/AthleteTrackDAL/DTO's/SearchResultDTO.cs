using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthleteTrackDAL.DTO_s
{
    public class SearchResultDTO
    {
        public string Name { get; set; } = "";
        public int ID { get; set; }
        public SearchType searchType { get; } = SearchType.Wedstrijdschema;

        public enum SearchType
        {
            Wedstrijdschema,
            Trainingsschema
        }

        public SearchResultDTO(SearchType searchtype) 
        {
            searchType = searchtype;
        }
    }
}
