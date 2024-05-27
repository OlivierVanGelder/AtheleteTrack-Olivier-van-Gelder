using AthleteTrackLogic.Classes;
using AthleteTrackLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
