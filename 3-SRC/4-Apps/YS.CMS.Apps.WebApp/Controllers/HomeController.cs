using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YS.CMS.Apps.WebApp.Models;
using YS.CMS.Domain.Base.Entities;
using YS.CMS.Infra.CrossCutting.Clients.Internal.Http.Controllers;

namespace YS.CMS.Apps.WebApp.Controllers
{
    // [Authorize]
    public class HomeController : Controller
    {
        private readonly PostClient _api;
        public HomeController(PostClient api)
        {
            _api = api;
        }


        public async Task<IActionResult> Index()
        {
            var post = new Post();
            post.Title = "ok";
            post.Text = "okok";
            post.CreateUser = Guid.NewGuid();
            post.Author = Guid.NewGuid();

            try
            {
                await _api.PostAsync(post);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                BadRequest();
            }

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
