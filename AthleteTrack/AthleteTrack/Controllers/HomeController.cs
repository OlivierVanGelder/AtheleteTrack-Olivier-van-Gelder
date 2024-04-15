using AthleteTrack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using AthleteTrack.Data;

namespace AthleteTrack.Controllers
{
    public class HomeController : Controller
    {
        

        private readonly ILogger<HomeController> _logger;

        private readonly Dataconnection _connection = new();

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            HomeModel model = new HomeModel();
            model.Results = _connection.GetWedstrijdschemas(model.Searchtext);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(string Searchtext)
        {
            HomeModel model = new HomeModel();
            if (Searchtext != null)
            {
                model.Searchtext = Searchtext;
            }
            else
            {
                model.Searchtext = " ";
            }
            model.Results = _connection.GetWedstrijdschemas(model.Searchtext);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}