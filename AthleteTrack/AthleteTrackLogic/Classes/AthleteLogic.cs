using AthleteTrackLogic.Interfaces;

namespace AthleteTrackLogic.Classes
{
    internal class AthleteLogic
    {
        IAthleteDAL _DAL;

        public AthleteLogic(IAthleteDAL dAL)
        {
            _DAL = dAL;
        }

        public List<Athlete> GetAtleet(int ID)
        {
            return _DAL.GetAtleet(ID);
        }
    }
}
