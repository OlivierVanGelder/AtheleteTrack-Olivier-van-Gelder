using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthleteTrackDAL.DTO_s
{
    public class DisciplineDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string StartTime { get; set; }
        public string Time { get; set; }
        public string Rules { get; set; }
        public int DisciplineID { get; set; }

        public List<AthleteDTO>? Athletes { get; set; } = new();
    }
}
