using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YS.CMS.Apps.WebApp.Models;
using YS.CMS.Infra.Clients.HTTP;

namespace YS.CMS.Apps.WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApiAuthProviderClient _api;

        public HomeController(ApiAuthProviderClient api)
        {
            _api = api;
        }
        
        public IActionResult Index()
        {
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
