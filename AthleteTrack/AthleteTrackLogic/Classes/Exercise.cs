namespace AthleteTrackLogic.Classes
{
    public class Exercise
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Repetitions { get; set; }
        public string Time { get; set; }

        public Exercise(string name, string description, int repetitions, string time, int id)
        {
            ID = id;
            Name = name;
            Description = description;
            Repetitions = repetitions;
            Time = time;
        }
    }
}
