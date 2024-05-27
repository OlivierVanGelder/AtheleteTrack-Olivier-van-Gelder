using AthleteTrackLogic.Classes;
using AthleteTrackLogic.Interfaces;

namespace AthleteTrackLogic
{
    public class TrainingLogic
    {
        public Training GetTraining(int ID, ITrainingDAL trainingDAL)
        {
            Training training = trainingDAL.GetTrainingsDetails(ID);

            return training;
        }

        public List<Exercise> GetAllExercises(IExerciseDAL exerciseDAL)
        {
            List<Exercise> exercises = exerciseDAL.GetAllExercises();

            return exercises;
        }

        public void AddTraining(Training training, ITrainingDAL trainingDAL)
        {
            trainingDAL.AddTraining(training);
        }
    }
}
