using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthleteTrackDAL.DTO_s
{
    public class TrainingDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string StartTime {  get; set; }
        public string EndTime { get; set; }

        public List<ExerciseDTO> Exercises { get; set; }
    }
}
