using AthleteTrack.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AthleteTrack.Controllers
{
    public class SchemapagesController : Controller
    {
        private readonly ILogger<SchemapagesController> _logger;

        public SchemapagesController(ILogger<SchemapagesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Trainingsschema()
        {
            return View();
        }
    }
}
