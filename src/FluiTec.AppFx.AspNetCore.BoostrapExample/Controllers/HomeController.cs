using Microsoft.AspNetCore.Mvc;

namespace FluiTec.AppFx.AspNetCore.BoostrapExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}