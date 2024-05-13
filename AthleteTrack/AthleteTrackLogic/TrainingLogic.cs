using AthleteTrackDAL;
using AthleteTrackLogic.Classes;
using AthleteTrackDAL.DTO_s;

namespace AthleteTrackLogic
{
    public class TrainingLogic
    {
        public Training GetTraining(int ID)
        {
            Training training = new();

            TrainingDAL trainingDAL = new TrainingDAL();

            TrainingDTO trainingDTO = trainingDAL.GetTrainingsDetails(ID);

            training.ID = trainingDTO.ID;
            training.Name = trainingDTO.Name;
            training.StartTime = trainingDTO.StartTime;
            training.EndTime = trainingDTO.EndTime;
            training.Exercises = new();
            foreach (ExerciseDTO exerciseDTO in trainingDTO.Exercises)
            {
                Exercise ex = new Exercise();
                ex.ID = exerciseDTO.ID;
                ex.Name = exerciseDTO.Name;
                ex.Description = exerciseDTO.Description;
                ex.Time = exerciseDTO.Time;
                ex.Repetitions = exerciseDTO.Repetitions;
                training.Exercises.Add(ex);
            }

            return training;
        }

        public List<Exercise> GetAllExercises()
        {
            List<Exercise> exercises = new();

            ExerciseDAL exerciseDAL = new();

            List<ExerciseDTO> exerciseDTO = exerciseDAL.GetAllExercises();

            foreach (ExerciseDTO exercise in exerciseDTO)
            {
                Exercise ex = new Exercise();
                ex.ID = exercise.ID;
                ex.Name = exercise.Name;
                ex.Description = exercise.Description;
                ex.Time = exercise.Time;
                ex.Repetitions = exercise.Repetitions;
                exercises.Add(ex);
            }

            return exercises;
        }

        public void AddTraining(Training training)
        {
            TrainingDAL trainingDAL = new();

            TrainingDTO trainingDTO = new();

            trainingDTO.ID = training.ID;
            trainingDTO.Name = training.Name;
            trainingDTO.StartTime = training.StartTime;
            trainingDTO.EndTime = training.EndTime;
            trainingDTO.Exercises = new();
            foreach (var exercise in training.Exercises)
            {
                ExerciseDTO exerciseDTO = new();
                exerciseDTO.ID = exercise.ID;
                exerciseDTO.Time = exercise.Time;
                exerciseDTO.Name = exercise.Name;
                exerciseDTO.Repetitions = exercise.Repetitions;
                exerciseDTO.Description = exercise.Description;
                trainingDTO.Exercises.Add(exerciseDTO);
            }

            trainingDAL.AddTraining(trainingDTO);
        }
    }
}
