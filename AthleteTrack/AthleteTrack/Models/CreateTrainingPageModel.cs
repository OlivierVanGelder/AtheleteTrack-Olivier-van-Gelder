using AthleteTrackLogic.Classes;

namespace AthleteTrackMVC.Models
{
    public class CreateTrainingPageModel
    {
        public string? Name { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string Action { get; set; } = "New";
        public List<Exercise> Exercises { get; set; }
        public List<Exercise> SelectedExercises { get; set; }
        public string? ErrorMessage { get; set; } = null;
        public string? SuccesMessage { get; set; } = null;
    }
}
