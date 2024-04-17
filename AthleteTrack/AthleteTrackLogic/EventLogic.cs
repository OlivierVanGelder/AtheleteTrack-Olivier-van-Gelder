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
            @event.StartTime = eventDTO.StartTime;
            @event.EndTime = eventDTO.EndTime;
            @event.Disciplines = new();
            foreach (DisciplineDTO disciplineDTO in eventDTO.Disciplines)
            {
                Discipline di = new();
                di.ID = disciplineDTO.ID;
                di.Name = disciplineDTO.Name;
                di.Rules = disciplineDTO.Rules;
                di.Time = disciplineDTO.Time;
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
                di.Time = discipline.Time;
                di.StartTime = discipline.StartTime;
                di.Rules = discipline.Rules;
                exercises.Add(di);
            }

            return exercises;
        }
    }
}
