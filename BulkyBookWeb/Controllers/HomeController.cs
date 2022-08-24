using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

// Controller - interface between Model and View to process all business logic and incoming req
// manipulates data using Model, handles user request
// interacts with View to render final output
// heart of the application

namespace BulkyBookWeb.Controllers
{
    // implements the default / base class - Controller
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // registering the logger using Dependency Injection
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Controller can have multiple action methods
        // IActionResult -> generic type which implements all the other return types
        // ActionResult -> parent class for many derived classes having associated helpers
        // IActionResult -> return type used when multiple ActionResult return types possible

        // Action method #1
        // If url is /Home/Index
        public IActionResult Index()
        {
            // View -> inside views folder
            // Will look for name of the controller -> 'Home' -> inside the Views folder
            // Action name 'Index.cshtml' will be inside the 'Home' folder
            return View();          // returns ViewResult
        }

        // Action method #2
        // url is /Home/Privacy
        public IActionResult Privacy()
        {
            // Will look for name of the controller -> 'Home' -> inside the Views folder
            // Action name 'Privacy.cshtml' will be inside the 'Home' folder
            return View();
        }

        // Action method #2
        // url is /Home/Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}