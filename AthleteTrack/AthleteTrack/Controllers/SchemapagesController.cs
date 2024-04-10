using AthleteTrack.Data;
using AthleteTrack.Models;
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

        public IActionResult Trainingsschema()
        {
            return View();
        }

        public IActionResult Wedstrijdschema(int ID, int OnderdeelID)
        {
            Debug.WriteLine($"ID: {ID}");
            _ = new WedstrijdPageModel();
            WedstrijdPageModel model = _connection.GetWedstrijdDetails(ID);
            if (OnderdeelID != null)
            {
                model.Atleten = _connection.GetAtleet(OnderdeelID);
                model.OnderdeelID = OnderdeelID;
            }
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
