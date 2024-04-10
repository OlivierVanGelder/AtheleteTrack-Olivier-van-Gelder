namespace AthleteTrack.Models
{
    public class WedstrijdPageModel
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string Datum { get; set; }  
        public string Begintijd { get; set; }
        public string Eindtijd { get; set; }
        public int OnderdeelID {  get; set; }
        public List<OnderdeelModel> Onderdelen {  get; set; }
        public List<Atleet> Atleten { get; set; }
    }
}
