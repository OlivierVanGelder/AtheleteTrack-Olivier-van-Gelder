using AthleteTrackLogic.Classes;
using AthleteTrackLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAthleteTrack
{
    [TestClass]
    public class TrainingLogicTest
    {
        [TestMethod]
        public void TestAddtraining()
        {
            // Arrange
            var mocktrainingDAL = new MockTrainingDAL();
            var trainingLogic = new TrainingLogic();
            Training training = new Training();
            training.StartTime = "10:00";
            training.EndTime = "12:00";
            training.Name = "Test training";
            training.Exercises.Add(new Exercise() { Repetitions = 56 });
            training.Exercises.Add(new Exercise() { Repetitions = 21 });
            training.Exercises.Add(new Exercise() { Repetitions = 15 });

            // Act
            bool result = trainingLogic.AddTraining(training, mocktrainingDAL);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestAddtrainingNoName()
        {
            // Arrange
            var mocktrainingDAL = new MockTrainingDAL();
            var trainingLogic = new TrainingLogic();
            Training training = new Training();
            training.StartTime = "10:00";
            training.EndTime = "12:00";

            // Act
            bool result = trainingLogic.AddTraining(training, mocktrainingDAL);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestAddtrainingNoStartTime()
        {
            // Arrange
            var mocktrainingDAL = new MockTrainingDAL();
            var trainingLogic = new TrainingLogic();
            Training training = new Training();
            training.EndTime = "12:00";
            training.Name = "Test training";

            // Act
            bool result = trainingLogic.AddTraining(training, mocktrainingDAL);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestAddtrainingNoEndTime()
        {
            // Arrange
            var mocktrainingDAL = new MockTrainingDAL();
            var trainingLogic = new TrainingLogic();
            Training training = new Training();
            training.StartTime = "10:00";
            training.Name = "Test training";

            // Act
            bool result = trainingLogic.AddTraining(training, mocktrainingDAL);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestAddtrainingNoRepetitions()
        {
            // Arrange
            var mocktrainingDAL = new MockTrainingDAL();
            var trainingLogic = new TrainingLogic();
            Training training = new Training();
            training.StartTime = "10:00";
            training.EndTime = "12:00";
            training.Name = "Test training";
            training.Exercises.Add(new Exercise() { Repetitions = 7 });
            training.Exercises.Add(new Exercise() { Repetitions = 12 });
            training.Exercises.Add(new Exercise() { Repetitions = 45 });
            training.Exercises.Add(new Exercise() { Repetitions = 0 });
            training.Exercises.Add(new Exercise() { Repetitions = 189 });
            training.Exercises.Add(new Exercise() { Repetitions = 5 });

            // Act
            bool result = trainingLogic.AddTraining(training, mocktrainingDAL);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
