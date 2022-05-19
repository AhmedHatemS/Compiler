using Microsoft.AspNetCore.Mvc;
using Scanner.Models;
using System.Diagnostics;

namespace Scanner.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Index(DealWithUI model)
        {
            return RedirectToAction("Scan", new {input = model.text});
        }

        public IActionResult Scan(string input)
        {
            ScannerImplementation scannerImplementation = new ScannerImplementation(input);
            DealWithUI model = new DealWithUI();
            model.nOfErrors = scannerImplementation.nOfErrors;
            model.Tokens = scannerImplementation.outputTokensList;
            model.Errors = scannerImplementation.outputErrorsList;
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}