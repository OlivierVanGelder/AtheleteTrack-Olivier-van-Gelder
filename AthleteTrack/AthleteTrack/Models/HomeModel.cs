namespace AthleteTrack.Models
{
    public class HomeModel
    {
        public string Searchtext { get; set; } = "";

        public List<SearchResultModel> Results { get; set; } = new();
    }
}