using Microsoft.AspNetCore.Mvc;

namespace Lesson01._3.Controllers
{
    public class LpthDemoHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
