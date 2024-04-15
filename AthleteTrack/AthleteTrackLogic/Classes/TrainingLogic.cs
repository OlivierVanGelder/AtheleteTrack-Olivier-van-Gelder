using AthleteTrackLogic.Interfaces;

namespace AthleteTrackLogic.Classes
{
    public class TrainingLogic
    {
        ITrainingDAL _DAL;

        public TrainingLogic(ITrainingDAL dal)
        {
            _DAL = dal;
        }

        public Training GetTrainingsDetails(int ID)
        {
            return _DAL.GetTrainingsDetails(ID);
        }
    }
}
