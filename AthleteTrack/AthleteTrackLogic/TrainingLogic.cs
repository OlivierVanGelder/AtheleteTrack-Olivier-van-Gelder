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
                throw new ArgumentException("EndTime cannot be empty");
            if (string.IsNullOrWhiteSpace(training.StartTime))
                throw new ArgumentException("StartTime cannot be empty");
            if (string.IsNullOrWhiteSpace(training.Name))
                throw new ArgumentException("Name cannot be empty");
            foreach (Exercise exercise in training.Exercises)
            {
                if (exercise.Repetitions <= 0)
                {
                    throw new ArgumentException("Repetitions cannot be 0 or less");
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
                throw new ArgumentException("Name cannot be empty");
            if (string.IsNullOrWhiteSpace(exercise.Description))
                throw new ArgumentException("Description cannot be empty");

            exercise.Name = exercise.Name.Trim();
            exercise.Description = exercise.Description.Trim();

            if (!exerciseDAL.AddExercise(exercise))
                return false;
            return true;
        }
    }
}
