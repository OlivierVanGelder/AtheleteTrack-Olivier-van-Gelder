using AthleteTrackLogic.Classes;
using AthleteTrackLogic.Interfaces;

namespace AthleteTrackLogic
{
    public class AtleetLogic
    {
        public List<Athlete> GetAtleten(int id, IAthleteDAL athleteDAL)
        {
            List<Athlete> athletes = athleteDAL.GetAtleten(id);

            return athletes;
        }
    }
}
