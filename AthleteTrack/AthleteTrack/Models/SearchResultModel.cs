namespace AthleteTrack.Models
{
    public class SearchResultModel
    {
        public string Name { get; set; } = "";
        public int ID { get; set; }

        public SearchResultModel(string name, int id)
        {
            Name = name;
            ID = id;
        }
    }
}