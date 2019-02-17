using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YS.CMS.Apps.WebApp.Models;
using YS.CMS.Infra.HttpClients;
using YS.CMS.Infra.Security.Model;

namespace YS.CMS.Apps.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiAuthProviderClient _api;

        public HomeController(ApiAuthProviderClient api)
        {
            _api = api;
        }

        public async Task<IActionResult> Index()
        {
            var model = new RegisterModel() { Login = "Mateus", Password = "123", ConfirmPassword = "123" };

            await _api.PostRegisterAsync(model);
            return RedirectToAction("About", "Home");
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
