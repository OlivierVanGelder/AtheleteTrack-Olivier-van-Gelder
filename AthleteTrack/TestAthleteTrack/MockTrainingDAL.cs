using AthleteTrackLogic.Classes;
using AthleteTrackLogic.Interfaces;

namespace TestAthleteTrack
{
    internal class MockTrainingDAL : ITrainingDAL
    {
        public void AddTraining(Training training) { }

        public Training MockTraining { get; set; } = new();

        public Training GetTrainingsDetails(int ID) => MockTraining;
    }
}
