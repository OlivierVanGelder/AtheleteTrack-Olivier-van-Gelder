using AthleteTrackMVC.Models;
using AthleteTrackLogic;
using AthleteTrackLogic.Classes;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using System.Diagnostics;

namespace AthleteTrack.Controllers
{
    public class SchemapagesController : Controller
    {
        private readonly ILogger<SchemapagesController> _logger;
        public CreateEventPageModel createEventPageModel = new();

        public SchemapagesController(ILogger<SchemapagesController> logger)
        {
            _logger = logger;

            createEventPageModel.SelectedDisciplines = new();
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
            model.SelectedDisciplines = new();
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateWedstrijdschema(string? SelectedDiscipline)
        {
            EventLogic eventLogic = new();

            createEventPageModel.Disciplines = eventLogic.GetAllDisciplines();
            createEventPageModel.SelectedDisciplines.Add(new Discipline { Name = SelectedDiscipline });
                
            return View(createEventPageModel);
        }

        public IActionResult CreateTrainingsschema()
        {
            CreateTrainingPageModel model = new();
            TrainingLogic trainingLogic = new();

            model.Exercises = trainingLogic.GetAllExercises();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
