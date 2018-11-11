using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Axxes.ToyCollector.Web.Models;

namespace Axxes.ToyCollector.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
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
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
