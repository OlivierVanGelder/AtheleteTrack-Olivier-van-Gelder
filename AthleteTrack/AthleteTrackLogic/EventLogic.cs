using AthleteTrackLogic.Classes;
using AthleteTrackLogic.Interfaces;

namespace AthleteTrackLogic
{
    public class EventLogic
    {
        public Event GetEvent(int ID, IEventDAL eventDAL)
        {
            Event @event = eventDAL.GetEventDetails(ID);

            return @event;
        }

        public List<Discipline> GetAllDisciplines(IDisciplinesDAL disciplinesDAL)
        {
            List<Discipline> exercises = disciplinesDAL.GetAllDisciplines();

            return exercises;
        }

        public void AddEvent(Event @event, IEventDAL eventDAL)
        {
            eventDAL.AddEvent(@event);
        }
    }
}