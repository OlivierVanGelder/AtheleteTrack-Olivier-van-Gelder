﻿using AthleteTrackDAL;
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
    }
}