using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Logging.Serilog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            _logger.LogInformation("ENTERED HOME");
            return View();
        }

        public IActionResult About([FromServices] ILogger<HomeController> logger)
        {
            logger.LogInformation("INJECT FROM ACTION ENTERED ABOUT");
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            var t = (ILogger)HttpContext.RequestServices.GetService(typeof(ILogger<HomeController>));
            t.LogInformation("INJECT DYNAMIC ENTERED CONTACT");
           
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
