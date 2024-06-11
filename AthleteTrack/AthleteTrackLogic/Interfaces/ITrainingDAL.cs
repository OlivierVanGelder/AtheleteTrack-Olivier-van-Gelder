using AthleteTrackLogic.Classes;

namespace AthleteTrackLogic.Interfaces
{
    public interface ITrainingDAL
    {
        public Training GetTrainingsDetails(int ID);

        public bool AddTraining(Training training);
    }
}
