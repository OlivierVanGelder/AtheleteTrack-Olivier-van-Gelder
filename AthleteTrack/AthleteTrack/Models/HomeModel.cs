namespace AthleteTrack.Models
{
    public class HomeModel
    {
        public string Searchtext { get; set; } = "";

        public List<AthleteTrackLogic.Classes.SearchResult> Results { get; set; } = new();
    }
}