using AthleteTrackLogic.Classes;

namespace AthleteTrackMVC.Models
{
    public class CreateEventPageModel
    {
        public string Name { get; set; }
        public string Date {  get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public List<Discipline> Disciplines { get; set; }
        public List<Discipline> SelectedDisciplines { get; set; }
    }
}
