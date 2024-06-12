using AthleteTrackLogic.Classes;
using AthleteTrackLogic;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

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

            try
            {
                // Act
                bool result = trainingLogic.AddTraining(training, mocktrainingDAL);

                // Assert
                Assert.IsTrue(result);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }
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

            try
            {
                // Act
                bool result = trainingLogic.AddTraining(training, mocktrainingDAL);

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Name cannot be empty", ex.Message);
            }
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

            try
            {
                // Act
                bool result = trainingLogic.AddTraining(training, mocktrainingDAL);

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("StartTime cannot be empty", ex.Message);
            }
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

            try
            {
                // Act
                bool result = trainingLogic.AddTraining(training, mocktrainingDAL);

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("EndTime cannot be empty", ex.Message);
            }
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

            try
            {
                // Act
                bool result = trainingLogic.AddTraining(training, mocktrainingDAL);

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Repetitions cannot be 0 or less", ex.Message);
            }
        }

        [TestMethod]
        public void TestAddExercise()
        {
            // Arrange
            var mockExerciseDAL = new MockExerciseDAL();
            var trainingLogic = new TrainingLogic();
            Exercise exercise = new Exercise();
            exercise.Description = "Test description";
            exercise.Name = "Test exercise";

            try
            {
                // Act
                bool result = trainingLogic.AddExercise(exercise, mockExerciseDAL);

                // Assert
                Assert.IsTrue(result);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestAddExerciseNoName()
        {
            // Arrange
            var mockExerciseDAL = new MockExerciseDAL();
            var trainingLogic = new TrainingLogic();
            Exercise exercise = new Exercise();
            exercise.Description = "Test description";

            try
            {
                // Act
                bool result = trainingLogic.AddExercise(exercise, mockExerciseDAL);

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Name cannot be empty", ex.Message);
            }
        }

        [TestMethod]
        public void TestAddExerciseNoDescription()
        {
            // Arrange
            var mockExerciseDAL = new MockExerciseDAL();
            var trainingLogic = new TrainingLogic();
            Exercise exercise = new Exercise();
            exercise.Name = "Test exercise";

            try
            {
                // Act
                bool result = trainingLogic.AddExercise(exercise, mockExerciseDAL);

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Description cannot be empty", ex.Message);
            }
        }
    }
}
