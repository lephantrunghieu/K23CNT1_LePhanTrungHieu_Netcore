using Microsoft.AspNetCore.Mvc;
using LpthLesson05.Models.Data_Models;
namespace LpthLesson05.Controllers
{
    public class LpthMemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LpthGetMember()
        {
            var lpthMember = new LpthMember();
            lpthMember.LpthMemberId = Guid.NewGuid().ToString();
            lpthMember.LpthUserName = "Trung Hieu";
            lpthMember.LpthFullName = "Le Phan Trung Hieu";
            lpthMember.LpthPassword = "Trunghieu123@";
            lpthMember.LpthEmail = "lephantrunghieu@gmail.com";

            ViewBag.lpthMember = lpthMember;
            return View();
            
        }
    }
}
