using AthleteTrack.Models;
using AthleteTrackDAL;
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
            AtleetDAL atleetDAL = new AtleetDAL();
            List<Atleet> atleten = new List<Atleet>();

            foreach (AtleetDTO atleet in atleetDAL.GetAtleten(id))
            {
                Atleet newAtleet = new();

                newAtleet.Name = atleet.Name;
                atleten.Add(newAtleet);
            }

            return atleten;
        }
    }
}
