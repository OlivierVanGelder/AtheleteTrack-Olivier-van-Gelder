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

            try
            {
                // Act
                bool result = eventLogic.AddEvent(@event, mockEventDAL);

                // Assert
                Assert.IsTrue(result);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }
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

            try
            {
                // Act
                bool result = eventLogic.AddEvent(@event, mockEventDAL);

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Name cannot be empty", ex.Message);
            }
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

            try
            {
                // Act
                bool result = eventLogic.AddEvent(@event, mockEventDAL);

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Date cannot be empty", ex.Message);
            }
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

            try
            {
                // Act
                bool result = eventLogic.AddEvent(@event, mockEventDAL);

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("StartTime cannot be empty", ex.Message);
            }
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

            try
            {
                // Act
                bool result = eventLogic.AddEvent(@event, mockEventDAL);

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("EndTime cannot be empty", ex.Message);
            }
        }
    }
}