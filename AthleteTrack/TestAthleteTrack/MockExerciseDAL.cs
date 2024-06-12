using AthleteTrackLogic.Classes;
using AthleteTrackLogic.Interfaces;

namespace TestAthleteTrack
{
    internal class MockExerciseDAL : IExerciseDAL
    {
        public bool AddExercise(Exercise exercise) { return true; }

        public Exercise MockExercise { get; set; } = new();

        public List<Exercise> GetAllExercises() => new();

        public List<Exercise> GetExercises(int ID) => new();
    }
}
