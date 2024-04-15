using AthleteTrackLogic.Interfaces;

namespace AthleteTrackLogic.Classes
{
    public class DisciplinesLogic
    {
        IDisciplineDAL _DAL;

        public DisciplinesLogic(IDisciplineDAL dal)
        {
            _DAL = dal;
        }

        public List<Discipline> GetDiscipline(int ID)
        {
            return _DAL.GetDiscipline(ID);
        }

        public List<Discipline> GetDisciplines()
        {
            return _DAL.GetDisciplines();
        }
    }
}
