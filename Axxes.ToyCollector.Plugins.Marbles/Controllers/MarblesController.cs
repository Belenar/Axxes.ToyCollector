using Microsoft.AspNetCore.Mvc;

namespace Axxes.ToyCollector.Plugins.Marbles.Controllers
{
    public class MarblesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
