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
            foreach (Exercise exercise in training.Exercises)
            {
                if (exercise.Repetitions <= 0)
                {
                    return false;
                }
            }

            training.EndTime = training.EndTime.Trim();
            training.StartTime = training.StartTime.Trim();
            training.Name = training.Name.Trim();

            trainingDAL.AddTraining(training);
            return true;
        }

        public bool AddExercise(Exercise exercise, IExerciseDAL exerciseDAL)
        {
            if (string.IsNullOrWhiteSpace(exercise.Name))
                return false;
            if (string.IsNullOrWhiteSpace(exercise.Description))
                return false;

            exercise.Name = exercise.Name.Trim();
            exercise.Description = exercise.Description.Trim();

            if (!exerciseDAL.AddExercise(exercise))
                return false;
            return true;
        }
    }
}
