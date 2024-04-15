namespace AthleteTrackLogic.Classes
{
    public class Discipline
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Begintijd { get; set; }
        public string Tijdsduur { get; set; }
        public string Regelementen { get; set; }
        public int OnderdeelID { get; set; }

        public Discipline(int id, string name, string begintijd, string tijdsduur, string regelementen, int onderdeelID) 
        {
            ID = id;
            Name = name;
            Begintijd = begintijd;
            Tijdsduur = tijdsduur;
            Regelementen = regelementen;
            OnderdeelID = onderdeelID;
        }
    }
}