using AthleteTrackDAL.DTO_s;
using AthleteTrackDAL;
using AthleteTrackLogic.Classes;

namespace AthleteTrackLogic
{
    public class EventLogic
    {
        public Event GetEvent(int ID)
        {
            Event @event = new();

            EventDAL eventDal = new();

            EventDTO eventDTO = eventDal.GetEventDetails(ID);

            @event.ID = eventDTO.ID;
            @event.Name = eventDTO.Name;
            @event.Date = eventDTO.Date;
            @event.StartTime = eventDTO.StartTime;
            @event.EndTime = eventDTO.EndTime;
            @event.Disciplines = new();
            foreach (DisciplineDTO disciplineDTO in eventDTO.Disciplines)
            {
                Discipline di = new();
                di.ID = disciplineDTO.ID;
                di.Name = disciplineDTO.Name;
                di.Rules = disciplineDTO.Rules;
                di.EndTime = disciplineDTO.EndTime;
                di.StartTime = disciplineDTO.StartTime;
                di.DisciplineID = disciplineDTO.DisciplineID;
                @event.Disciplines.Add(di);
            }

            return @event;
        }

        public List<Discipline> GetAllDisciplines()
        {
            List<Discipline> exercises = new();

            DisciplinesDAL exerciseDAL = new();

            List<DisciplineDTO> disciplineDTO = exerciseDAL.GetAllDisciplines();

            foreach (DisciplineDTO discipline in disciplineDTO)
            {
                Discipline di = new();
                di.ID = discipline.ID;
                di.Name = discipline.Name;
                di.DisciplineID = discipline.DisciplineID;
                di.EndTime = discipline.EndTime;
                di.StartTime = discipline.StartTime;
                di.Rules = discipline.Rules;
                di.Athletes = new();
                exercises.Add(di);
            }

            return exercises;
        }

        public void AddEvent(Event @event)
        {
            EventDAL eventDAL = new();

            EventDTO eventDTO = new();

            eventDTO.ID = @event.ID;
            eventDTO.Name = @event.Name;
            eventDTO.StartTime = @event.StartTime;
            eventDTO.EndTime = @event.EndTime;
            eventDTO.Date = @event.Date;
            eventDTO.Disciplines = new();
            foreach(var discipline in @event.Disciplines)
            {
                DisciplineDTO disciplineDTO = new();
                disciplineDTO.ID = discipline.ID;
                disciplineDTO.Athletes = new();
                disciplineDTO.StartTime = discipline.StartTime;
                disciplineDTO.EndTime = discipline.EndTime;
                if (discipline.Athletes != null)
                {
                    foreach (var athlete in discipline.Athletes)
                    {
                        AthleteDTO athleteDTO = new();
                        athleteDTO.ID = athlete.ID;
                        athleteDTO.Name = athlete.Name;
                        disciplineDTO.Athletes.Add(athleteDTO);
                    }
                }
                eventDTO.Disciplines.Add(disciplineDTO);
            }

            eventDAL.AddEvent(eventDTO);
        }
    }
}