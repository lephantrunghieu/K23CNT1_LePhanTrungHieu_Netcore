using System.Diagnostics;
using LpthLesson03.Models;
using Microsoft.AspNetCore.Mvc;

namespace LpthLesson03.Controllers
{
    public class LpthHomeController : Controller
    {
        private readonly ILogger<LpthHomeController> _logger;

        public LpthHomeController(ILogger<LpthHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult LpthIndex()
        {
            return View();
        }

        public IActionResult LpthAbout()
        {
            @ViewBag.about = "Hieu Le";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult LpthProfile()
        {
            return View();
        }
        public IActionResult LpthRazerCode()
        {
            return View();
        }
    }
}
