using AthleteTrackLogic;
using AthleteTrackLogic.Classes;

namespace TestAthleteTrack
{
    [TestClass]
    public class EventLogicTests
    {
        [TestMethod]
        public void TestAddEvent()
        {
            // Arrange
            var mockEventDAL = new MockEventDAL();
            var eventLogic = new EventLogic();
            Event @event = new Event();
            @event.Date = "2022-01-01";
            @event.StartTime = "10:00";
            @event.EndTime = "12:00";
            @event.Name = "Test Event";

            // Act
            bool result = eventLogic.AddEvent(@event, mockEventDAL);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestAddEventNoName()
        {
            // Arrange
            var mockEventDAL = new MockEventDAL();
            var eventLogic = new EventLogic();
            Event @event = new Event();
            @event.Date = "2022-01-01";
            @event.StartTime = "10:00";
            @event.EndTime = "12:00";

            // Act
            bool result = eventLogic.AddEvent(@event, mockEventDAL);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestAddEventNoDate()
        {
            // Arrange
            var mockEventDAL = new MockEventDAL();
            var eventLogic = new EventLogic();
            Event @event = new Event();
            @event.StartTime = "10:00";
            @event.EndTime = "12:00";
            @event.Name = "Test Event";

            // Act
            bool result = eventLogic.AddEvent(@event, mockEventDAL);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestAddEventNoStartTime()
        {
            // Arrange
            var mockEventDAL = new MockEventDAL();
            var eventLogic = new EventLogic();
            Event @event = new Event();
            @event.Date = "2022-01-01";
            @event.EndTime = "12:00";
            @event.Name = "Test Event";

            // Act
            bool result = eventLogic.AddEvent(@event, mockEventDAL);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestAddEventNoEndTime()
        {
            // Arrange
            var mockEventDAL = new MockEventDAL();
            var eventLogic = new EventLogic();
            Event @event = new Event();
            @event.Date = "2022-01-01";
            @event.StartTime = "10:00";
            @event.Name = "Test Event";

            // Act
            bool result = eventLogic.AddEvent(@event, mockEventDAL);

            // Assert
            Assert.IsFalse(result);
        }
    }
}