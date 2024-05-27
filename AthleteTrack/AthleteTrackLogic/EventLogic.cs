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

        public bool AddEvent(Event @event, IEventDAL eventDAL)
        {
            if (string.IsNullOrWhiteSpace(@event.Date))
                return false;
            if (string.IsNullOrWhiteSpace(@event.EndTime)) 
                return false;
            if (string.IsNullOrWhiteSpace(@event.StartTime))
                return false;
            if (string.IsNullOrWhiteSpace(@event.Name))
                return false;

            @event.Date = @event.Date.Trim();
            @event.EndTime = @event.EndTime.Trim();
            @event.StartTime = @event.StartTime.Trim();
            @event.Name = @event.Name.Trim();

            eventDAL.AddEvent(@event);
            return true;
        }
    }
}