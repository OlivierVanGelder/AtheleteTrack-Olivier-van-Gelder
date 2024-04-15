namespace AthleteTrackLogic.Classes
{
    public class SearchResultModel
    {
        public string Name { get; set; } = "";
        public int ID { get; set; }
        public SearchType searchType { get; } = SearchType.Wedstrijdschema;

        public SearchResultModel(string name, int id, SearchType searchtype)
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