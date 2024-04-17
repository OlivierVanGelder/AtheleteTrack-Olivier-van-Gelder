using AthleteTrackLogic.Classes;

namespace AthleteTrack.Models
{
    public class TrainingsPageModel
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int ExerciseID {  get; set; }
        public List<Exercise> Exercises { get; set; }
    }
}
