using AthleteTrackDAL;
using AthleteTrackLogic.Classes;
using AthleteTrackDAL.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthleteTrackLogic
{
    public class AtleetLogic
    {
        public List<Atleet> GetAtleten(int id)
        {
            AthleteDAL atleetDAL = new AthleteDAL();
            List<Atleet> atleten = new List<Atleet>();

            foreach (AthleteDTO atleet in atleetDAL.GetAtleten(id))
            {
                Atleet newAtleet = new();

                newAtleet.ID = atleet.ID;
                newAtleet.Name = atleet.Name;
                atleten.Add(newAtleet);
            }

            return atleten;
        }
    }
}
