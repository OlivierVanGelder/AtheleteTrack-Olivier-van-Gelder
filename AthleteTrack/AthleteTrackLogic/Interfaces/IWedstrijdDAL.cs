using AthleteTrackLogic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthleteTrackLogic.Interfaces
{
    public interface IWedstrijdDAL
    {
        public Wedstrijd GetWedstrijdDetails(int ID);

        public List<SearchResultModel> GetSchemas(string naam);
    }
}