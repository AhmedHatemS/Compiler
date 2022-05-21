using Microsoft.AspNetCore.Mvc;
using Compiler.Models;
using System.Diagnostics;

namespace Compiler.Controllers
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
        public IActionResult Index(DealWithUI model, string ScanParse)
        {
            if (ScanParse == "Scan")
            {
                return RedirectToAction("Scan", new { input = model.text });
            }
            return RedirectToAction("Parse", new {input = model.text});
        }

        public IActionResult Scan(string input)
        {
            ScannerImplementation scannerImplementation = new ScannerImplementation(input);
            DealWithUI model = new DealWithUI();
            model.nOfErrors = scannerImplementation.GetErrorsNum();
            model.Tokens = scannerImplementation.GetTokensList();
            model.Errors = scannerImplementation.GetErrorsList();
            return View(model);
        }
        public IActionResult Parse(string input)
        {
            ScannerImplementation scannerImplementation = new ScannerImplementation(input);
            DealWithUI model = new DealWithUI();
            model.nOfErrors = scannerImplementation.GetErrorsNum();
            model.Tokens = scannerImplementation.GetTokensList();
            model.Errors = scannerImplementation.GetErrorsList();
            
            if(model.nOfErrors > 0)
            {
                return View(model);
            }
            else
            {
                ParserImplemintation parserImplemintation = new ParserImplemintation(scannerImplementation.GetTokens());
                model.Accepted = parserImplemintation.GetAcceptanceState();
                model.MatchedTokens = parserImplemintation.GetMatchedTokensList();
                model.NotMatchedTokens = parserImplemintation.GetNotMatchedTokensList();
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