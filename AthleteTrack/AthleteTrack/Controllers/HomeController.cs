using AthleteTrack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Data;

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
            model.Searchtext = string.Empty;

            string connectionstring = "Server=mssqlstud.fhict.local;Database=dbi536130_athletet;User Id=dbi536130_athletet;Password=123;TrustServerCertificate=True;";
            SqlConnection s = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Wedstrijdschema", s);
            s.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                SearchResultModel item = new(reader.GetString(1), reader.GetInt32(0));
                model.Results.Add(item);
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