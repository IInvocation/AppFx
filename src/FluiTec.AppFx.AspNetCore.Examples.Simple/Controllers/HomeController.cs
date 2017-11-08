using Microsoft.AspNetCore.Mvc;

namespace FluiTec.AppFx.AspNetCore.Examples.Simple.Controllers
{
    public class HomeController : Controller
    {
		// GET: Home/Index
        public IActionResult Index()
        {
	        return View();
        }
    }
}