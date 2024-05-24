namespace AthleteTrackLogic.Classes
{
    public class SearchResult
    {
        public string Name { get; set; } = "";
        public int ID { get; set; } = 0;
        public SearchType searchType { get; } = SearchType.Wedstrijdschema;

        public SearchResult(string name, int id, SearchType searchtype)
        {
            Name = name;
            ID = id;
            searchType = searchtype;
        }

        public enum SearchType
        {
            Wedstrijdschema,
            Trainingsschema
        }
    }
}