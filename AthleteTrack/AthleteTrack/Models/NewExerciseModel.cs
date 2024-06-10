using AthleteTrackLogic.Classes;

namespace AthleteTrackMVC.Models
{
    public class NewExerciseModel
    {
        public Exercise NewExercise { get; set; } = new();
        public string? ErrorMessage { get; set; }
    }
}
