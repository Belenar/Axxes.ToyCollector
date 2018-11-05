using Microsoft.AspNetCore.Mvc;

namespace Axxes.ToyCollector.Plugins.Lego.Controllers
{
    public class LegoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
