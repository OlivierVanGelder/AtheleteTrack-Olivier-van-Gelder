﻿namespace AthleteTrackLogic.Classes
{
    public class Discipline
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? Rules { get; set; }
        public int? DisciplineID { get; set; }
        public List<Athlete> Athletes { get; set; } = new();
        public string SelectedAthlete { get; set; } = string.Empty;
    }
}