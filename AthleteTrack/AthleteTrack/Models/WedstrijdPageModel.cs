using AthleteTrackLogic.Classes;

namespace AthleteTrackMVC.Models
{
    public class WedstrijdPageModel
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string Date { get; set; }  
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int OnderdeelID {  get; set; }
        public List<Discipline> Disciplines {  get; set; }
        public List<Atleet> Atleten { get; set; }
    }
}
