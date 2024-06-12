using AthleteTrackLogic.Classes;

namespace AthleteTrackLogic.Interfaces
{
    public interface IAthleteDAL
    {
        public List<Athlete> GetAtleten(int ID);
    }
}