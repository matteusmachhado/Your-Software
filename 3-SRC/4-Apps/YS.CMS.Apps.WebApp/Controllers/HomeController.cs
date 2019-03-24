using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using YS.CMS.Apps.WebApp.Models;

namespace YS.CMS.Apps.WebApp.Controllers
{
    // [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "WebApp";
            return View();
        }
        
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
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
