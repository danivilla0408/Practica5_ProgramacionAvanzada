using APS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using APS.Web.Filters;
using Microsoft.AspNetCore.Authorization;

namespace APS.Web.Controllers
{

    [Authorize]
    public class TestController : Controller
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

     

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
