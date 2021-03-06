﻿using System;
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

        public IActionResult Index()
        {
            ViewData["Title"] = "Home";
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
