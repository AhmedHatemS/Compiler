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
            ScannerImplementation scannerImplementation = new ScannerImplementation(model.text);

            model.nOfErrors = scannerImplementation.nOfErrors;
            model.Tokens = scannerImplementation.outputTokensList;
            model.Errors = scannerImplementation.outputErrorsList;

            string tkn = "";
            for(int i = 0; i < model.Tokens.Count; i++)
            {
                tkn+= "Line: "+model.Tokens[i].line.ToString()+
                    " Token text: "+ model.Tokens[i].keyword.ToString()+
                    " Token type: "+ model.Tokens[i].returnToken.ToString()+
                    "\n";
            }
            string error = "";
            for (int i = 0; i < model.Errors.Count; i++)
            {
                error += "Line: " + model.Errors[i].line.ToString() +
                    " Error text: " + model.Errors[i].keyword.ToString() +
                    "\n";
            }

            return Content($"{tkn}\nTotal NO of errors: {model.nOfErrors}\n{error}");
        }
                
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}