using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var t = (ILogger)HttpContext.RequestServices.GetService(typeof(ILogger<TestController>));
            t.LogInformation("INJECT DYNAMIC ENTERED TEST CONTROLLER");
            return View();
        }
    }
}
