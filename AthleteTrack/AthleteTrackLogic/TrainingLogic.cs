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

        public bool AddTraining(Training training, ITrainingDAL trainingDAL)
        {

            if (string.IsNullOrWhiteSpace(training.EndTime))
                return false;
            if (string.IsNullOrWhiteSpace(training.StartTime))
                return false;
            if (string.IsNullOrWhiteSpace(training.Name))
                return false;

            training.EndTime = training.EndTime.Trim();
            training.StartTime = training.StartTime.Trim();
            training.Name = training.Name.Trim();

            trainingDAL.AddTraining(training);
            return true;
        }
    }
}
