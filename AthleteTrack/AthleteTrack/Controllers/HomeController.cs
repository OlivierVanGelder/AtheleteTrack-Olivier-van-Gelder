using AthleteTrack.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            var model = new HomeModel();
            model.Results = GetMockResults();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(HomeModel model)
        {
            model.Results = GetMockResults();
            return View(model);
        }

        private List<SearchResultModel> GetMockResults()
        {
            return new List<SearchResultModel>
            {
                new SearchResultModel("First result", 1),
                new SearchResultModel("Second result", 2),
                new SearchResultModel("Third result", 3),
            };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
