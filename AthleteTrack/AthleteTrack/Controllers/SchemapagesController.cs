using AthleteTrack.Data;
using AthleteTrack.Models;
using AthleteTrackLogic;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AthleteTrack.Controllers
{
    public class SchemapagesController : Controller
    {
        private readonly ILogger<SchemapagesController> _logger;

        private readonly Dataconnection _connection = new();

        public SchemapagesController(ILogger<SchemapagesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Trainingsschema(int ID, int ExerciseID)
        {
            _ = new TrainingsPageModel();
            TrainingsPageModel model = _connection.GetTrainingsDetails(ID);
            if (ExerciseID != null)
            {
                model.ExerciseID = ExerciseID;
            }
            return View(model);
        }

        public IActionResult Wedstrijdschema(int ID, int DisciplineID)
        {
            AtleetLogic atleetLogic = new();

            WedstrijdPageModel model = new WedstrijdPageModel();
            if (DisciplineID != 0)
            {
                model.Atleten = atleetLogic.GetAtleten(DisciplineID);
                model.OnderdeelID = DisciplineID;
            }

            //WedstrijdPageModel model = _connection.GetWedstrijdDetails(ID);
            //if (DisciplineID != null)
            //{
            //    model.Atleten = _connection.GetAtleet(DisciplineID);
            //    model.OnderdeelID = DisciplineID;
            //}
            return View(model);
        }

        public IActionResult CreateWedstrijdschema()
        { 
            return View(); 
        }

        public IActionResult CreateTrainingsschema()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
