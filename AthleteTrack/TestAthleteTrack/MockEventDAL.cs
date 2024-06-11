using AthleteTrackLogic.Classes;
using AthleteTrackLogic.Interfaces;

namespace TestAthleteTrack
{
    internal class MockEventDAL : IEventDAL
    {
        public bool AddEvent(Event @event) { return true; }

        public Event MockEvent { get; set; } = new();

        public Event GetEventDetails(int ID) => MockEvent;
    }
}
