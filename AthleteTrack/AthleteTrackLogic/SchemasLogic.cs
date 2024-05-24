using AthleteTrackLogic.Interfaces;
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
        public List<SearchResult> GetSchemas(string searchtext, ISchemasDAL schemasDAL)
        {
            List<SearchResult> results = schemasDAL.GetSchemas(searchtext);

            return results;
        }
    }
}
