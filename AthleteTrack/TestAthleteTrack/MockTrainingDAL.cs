using AthleteTrackLogic.Classes;
using AthleteTrackLogic.Interfaces;

namespace TestAthleteTrack
{
    internal class MockTrainingDAL : ITrainingDAL
    {
        public bool AddTraining(Training training) { return true; }

        public Training MockTraining { get; set; } = new();

        public Training GetTrainingsDetails(int ID) => MockTraining;
    }
}
