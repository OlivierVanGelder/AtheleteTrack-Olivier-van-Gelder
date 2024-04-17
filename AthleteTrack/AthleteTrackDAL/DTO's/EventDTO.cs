using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthleteTrackDAL.DTO_s
{
    public class EventDTO
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Date {  get; set; }
        public List<DisciplineDTO> Disciplines { get; set; }
    }
}
