using AthleteTrackLogic.Interfaces;

namespace AthleteTrackLogic.Classes
{
    public class ExerciseLogic
    {
        IExerciseDAL _DAL;

        public ExerciseLogic(IExerciseDAL dal) 
        {
            _DAL = dal;
        }

        public List<Exercise> GetExercises(int id)
        {
            return _DAL.GetExercises(id);
        }

        public List<Exercise> GetAllExercises()
        {
            return _DAL.GetAllExercises();
        }
    }
}
