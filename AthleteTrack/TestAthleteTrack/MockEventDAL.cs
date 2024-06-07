using AthleteTrackLogic.Classes;
using AthleteTrackLogic.Interfaces;

namespace TestAthleteTrack
{
    internal class MockEventDAL : IEventDAL
    {
        public void AddEvent(Event @event) { }

        public Event MockEvent { get; set; } = new();

        public Event GetEventDetails(int ID) => MockEvent;
    }
}
