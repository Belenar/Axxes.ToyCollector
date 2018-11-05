using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Axxes.ToyCollector.Core.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;
using Axxes.ToyCollector.Web.Models;

namespace Axxes.ToyCollector.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IToyRepository _repo;

        public HomeController(IToyRepository repo)
        {
            _repo = repo;
            var toys = repo.GetAll();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "About this application";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact details";

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
