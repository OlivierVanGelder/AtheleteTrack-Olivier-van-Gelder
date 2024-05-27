<<<<<<<< HEAD:AthleteTrack/AthleteTrack/Logic/SearchResultModel.cs
﻿namespace AthleteTrack.Logic
========
﻿namespace AthleteTrackLogic.Classes
>>>>>>>> 3832ae2b48daaa1f58f8330660526af26f0d7c44:AthleteTrack/AthleteTrackLogic/Classes/SearchResult.cs
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