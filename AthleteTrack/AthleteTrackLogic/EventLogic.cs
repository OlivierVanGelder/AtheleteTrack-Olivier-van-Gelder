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
                throw new ArgumentException("Date cannot be empty");
            if (string.IsNullOrWhiteSpace(@event.EndTime))
                throw new ArgumentException("EndTime cannot be empty");
            if (string.IsNullOrWhiteSpace(@event.StartTime))
                throw new ArgumentException("StartTime cannot be empty");
            if (string.IsNullOrWhiteSpace(@event.Name))
                throw new ArgumentException("Name cannot be empty");

            @event.Date = @event.Date.Trim();
            @event.EndTime = @event.EndTime.Trim();
            @event.StartTime = @event.StartTime.Trim();
            @event.Name = @event.Name.Trim();

            return eventDAL.AddEvent(@event);
        }
    }
}