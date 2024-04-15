using AthleteTrack.Data;
using AthleteTrack.Logic;
using AthleteTrack.Models;
using AthleteTrackLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AthleteTrackDAL;
using AthleteTrackLogic.Classes;

namespace AthleteTrack.Controllers
{
    public class SchemapagesController : Controller
    {
        IConfiguration _configuration;

        private readonly ILogger<SchemapagesController> _logger;

        private readonly Dataconnection _connection = new();

        public SchemapagesController(ILogger<SchemapagesController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Trainingsschema(int ID, int ExerciseID)
        {
            TrainingsPageModel model = _connection.GetTrainingsDetails(ID);
            if (ExerciseID != null)
            {
                model.ExerciseID = ExerciseID;
            }
            return View(model);
        }

        public IActionResult Wedstrijdschema(int ID, int DisciplineID)
        {
            IExerciseDAL exerciseDAL = new ExerciseDAL(_configuration.GetConnectionString("Database"));
            ExerciseLogic exerciseLogic = new(exerciseDAL);



            WedstrijdPageModel model = _connection.GetWedstrijdDetails(ID);
            if (DisciplineID != null)
            {
                model.Atleten = _connection.GetAtleet(DisciplineID);
                model.OnderdeelID = DisciplineID;
            }
            return View(model);
        }

        public IActionResult CreateWedstrijdschema()
        {
            CreateWedstrijdPageModel model = new();
            model.Disciplines = _connection.GetAllDisciplines();
            return View(model); 
        }

        public IActionResult CreateTrainingsschema()
        {
            _ = new CreateTrainingsPageModel();
            CreateTrainingsPageModel model = new();
            model.Exercises = _connection.GetAllExercises();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
