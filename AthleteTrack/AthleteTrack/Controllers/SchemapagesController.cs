using AthleteTrackMVC.Models;
using AthleteTrackLogic;
using AthleteTrackLogic.Classes;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AthleteTrackDAL.DTO_s;

namespace AthleteTrack.Controllers
{
    public class SchemapagesController : Controller
    {
        private readonly ILogger<SchemapagesController> _logger;

        public SchemapagesController(ILogger<SchemapagesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Trainingsschema(int ID, int ExerciseID)
        {
            TrainingLogic trainingLogic = new TrainingLogic();
            TrainingsPageModel model = new();
            Training training = trainingLogic.GetTraining(ID);
            model.ID = training.ID;
            model.StartTime = training.StartTime;
            model.EndTime = training.EndTime;
            model.Name = training.Name;
            model.Exercises = training.Exercises;
            if (ExerciseID != null)
            {
                model.ExerciseID = ExerciseID;
            }
            return View(model);
        }

        public IActionResult Wedstrijdschema(int ID, int DisciplineID)
        {
            AtleetLogic atleetLogic = new();
            EventLogic eventLogic = new();

            WedstrijdPageModel model = new();
            Event @event = eventLogic.GetEvent(ID);
            model.ID = @event.ID;
            model.StartTime = @event.StartTime;
            model.EndTime = @event.EndTime;
            model.Name = @event.Name;
            model.Date = @event.Date;
            model.Disciplines = @event.Disciplines;
            model.Atleten = new();
            if (DisciplineID != 0)
            {
                model.Atleten = atleetLogic.GetAtleten(DisciplineID);
                model.OnderdeelID = DisciplineID;
            }
            return View(model);
        }

        public IActionResult CreateWedstrijdschema()
        {
            CreateEventPageModel model = new();
            EventLogic eventLogic = new();

            model.Disciplines = eventLogic.GetAllDisciplines();
            model.SelectedDisciplines.Add(new Discipline { Name = "60m sprint", StartTime = "00:00", EndTime = "00:00", Athletes = new() });
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateWedstrijdschema(CreateEventPageModel model)
        {
            EventLogic eventLogic = new();

            model.Disciplines = eventLogic.GetAllDisciplines();
            if(model.Action == "New")
                model.SelectedDisciplines.Add(new Discipline { Name = "", StartTime = "00:00", EndTime = "00:00", Athletes = new() });

            if (model.Action == "Save")
            {
                foreach (var discipline in model.SelectedDisciplines)
                {
                    if (discipline.SelectedAthlete != null && discipline.SelectedAthlete.Trim() != "")
                    {
                        discipline.Athletes.Add(new Atleet {Name = discipline.SelectedAthlete});
                    }
                }
            }

            if (model.Action == "Save all")
            {
                Event @event = new();

                @event.StartTime = model.StartTime;
                @event.EndTime = model.EndTime;
                @event.Date = model.Date;
                @event.Name = model.Name;

                foreach (var selecteddiscipline in model.SelectedDisciplines)
                {
                    foreach(var discipline in model.Disciplines)
                    {
                        if(discipline.Name == selecteddiscipline.Name)
                        {
                            selecteddiscipline.ID = discipline.ID;
                        }
                    }
                }

                @event.Disciplines = model.SelectedDisciplines;
                eventLogic.AddEvent(@event);
            }
            return View(model);
        }

        public IActionResult CreateTrainingsschema()
        {
            CreateTrainingPageModel model = new();
            TrainingLogic trainingLogic = new();

            model.Exercises = trainingLogic.GetAllExercises();
            model.SelectedExercises = new();
            model.SelectedExercises.Add(new Exercise {Name = "Pushups"});
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateTrainingsschema(CreateTrainingPageModel model)
        {
            TrainingLogic trainingLogic = new();

            model.Exercises = trainingLogic.GetAllExercises();
            if (model.Action == "New")
                model.SelectedExercises.Add(new Exercise { Name = "Pushup"});

            if (model.Action == "Save")
            {
                Training training = new();

                training.StartTime = model.StartTime;
                training.EndTime = model.EndTime;
                training.Name = model.Name;

                foreach(var selectedexercise in model.SelectedExercises)
                {
                    foreach(var exercise in model.Exercises)
                    {
                        if(exercise.Name == selectedexercise.Name)
                        {
                            selectedexercise.ID = exercise.ID;
                        }
                    }
                }

                training.Exercises = model.SelectedExercises;
                trainingLogic.AddTraining(training);
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
