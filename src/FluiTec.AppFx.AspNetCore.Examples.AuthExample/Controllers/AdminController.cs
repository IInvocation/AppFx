using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Controllers
{
    /// <summary>   A controller for handling admin operations. </summary>
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        /// <summary>   Gets the index. </summary>
        /// <returns>   An IActionResult. </returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
