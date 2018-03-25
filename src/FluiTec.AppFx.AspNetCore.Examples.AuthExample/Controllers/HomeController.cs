using Microsoft.AspNetCore.Mvc;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Controllers
{
    /// <summary>A controller for handling homes.</summary>
    public class HomeController : Controller
    {
        /// <summary>Gets the index.</summary>
        /// <returns>An IActionResult.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>Gets the about.</summary>
        /// <returns>An IActionResult.</returns>
        public IActionResult About()
        {
            return View();
        }
    }
}