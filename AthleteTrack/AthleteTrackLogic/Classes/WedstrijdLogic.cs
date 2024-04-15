using AthleteTrackLogic.Interfaces;

namespace AthleteTrackLogic.Classes
{
    public class WedstrijdLogic
    {
        IWedstrijdDAL _DAL;

        public WedstrijdLogic(IWedstrijdDAL dAL)
        {
            _DAL = dAL;
        }

        public List<SearchResultModel> GetSchemas(string naam)
        {
            return _DAL.GetSchemas(naam);
        }

        public Wedstrijd GetWedstrijdDetails(int ID)
        {
            return _DAL.GetWedstrijdDetails(ID);
        }
    }
}
