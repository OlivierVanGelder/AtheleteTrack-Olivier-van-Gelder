using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AthleteTrackLogic.Classes;

namespace AthleteTrackLogic.Interfaces
{
    public interface IExerciseDAL
    {
        public List<Exercise> GetExercises(int id);

        public List<Exercise> GetAllExercises();
    }
}