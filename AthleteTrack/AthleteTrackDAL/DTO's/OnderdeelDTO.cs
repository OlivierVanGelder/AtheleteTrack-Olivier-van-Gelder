using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthleteTrackDAL.DTO_s
{
    public class OnderdeelDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Begintijd { get; set; }
        public string Tijdsduur { get; set; }
        public string Regelementen { get; set; }
        public int OnderdeelID { get; set; }
    }
}
