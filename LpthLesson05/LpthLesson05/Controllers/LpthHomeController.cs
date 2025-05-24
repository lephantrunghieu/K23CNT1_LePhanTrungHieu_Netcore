using System.Diagnostics;
using LpthLesson05.Models;
using Microsoft.AspNetCore.Mvc;

namespace LpthLesson05.Controllers
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
