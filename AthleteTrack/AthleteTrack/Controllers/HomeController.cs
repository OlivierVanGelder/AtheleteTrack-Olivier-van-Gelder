using AthleteTrackMVC.Models;
using Microsoft.AspNetCore.Mvc;
using AthleteTrackDAL;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using AthleteTrackLogic;
using AthleteTrackLogic.Interfaces;

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
            Schema_sDAL schemasDAL = new();

            model.Results = schemasLogic.GetSchemas(model.Searchtext, schemasDAL);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(string Searchtext)
        {
            HomeModel model = new HomeModel();
            SchemasLogic schemasLogic = new SchemasLogic();
            Schema_sDAL schema_SDAL = new();

            if (Searchtext != null)
            {
                model.Searchtext = Searchtext;
            }
            else
            {
                model.Searchtext = "";
            }
            model.Results = schemasLogic.GetSchemas(model.Searchtext, schema_SDAL);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}