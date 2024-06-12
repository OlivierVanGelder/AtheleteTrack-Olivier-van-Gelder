using AthleteTrackLogic.Classes;
namespace AthleteTrackLogic.Interfaces
{
    public interface IExerciseDAL
    {
        public List<Exercise> GetExercises(int ID);

        public List<Exercise> GetAllExercises();
        public bool AddExercise(Exercise exercise);
    }
}
