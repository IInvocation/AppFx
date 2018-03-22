using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using WebApplication1.Models;
using WebApplication1.Resources;
using FluiTec.AppFx.Localization;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<ControllerResource> _localizer;

        public HomeController(IStringLocalizer<ControllerResource> localizer)
        {
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            ViewData["Controller"] = _localizer.GetString(r => ControllerResource.Name);
            return View(new IndexViewModel());
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
