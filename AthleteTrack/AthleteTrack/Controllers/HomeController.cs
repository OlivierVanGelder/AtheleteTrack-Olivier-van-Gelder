using AthleteTrackMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using AthleteTrackLogic;

namespace AthleteTrack.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HomeModel model = new HomeModel();
            SchemasLogic schemasLogic = new SchemasLogic();

            model.Results = schemasLogic.GetSchemas(model.Searchtext);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(string Searchtext)
        {
            HomeModel model = new HomeModel();
            SchemasLogic schemasLogic = new SchemasLogic();

            if (Searchtext != null)
            {
                model.Searchtext = Searchtext;
            }
            else
            {
                model.Searchtext = "";
            }
            model.Results = schemasLogic.GetSchemas(model.Searchtext);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}