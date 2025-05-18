using Microsoft.AspNetCore.Mvc;
using Lab02.Models;
namespace Lab02.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            List<Account> accounts = new List<Account>();
            {
                new Account()
                {
                    Id = 1,
                    Name = "Hoàng Anh",
                    Email = "anh@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Avatar/1.jpg"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(1998, 7, 15)
                };
                new Account()
                {
                    Id = 2,
                    Name = "Hoàng Anh1",
                    Email = "an1h@gmail.com",
                    Phone = "09861456789",
                    Address = "Hà Nội 2",
                    Avatar = Url.Content("~/Avatar/2.jpg"),
                    Gender = 1,
                    Bio = "My name is big",
                    Birthday = new DateTime(2003, 7, 15)
                };
            };
            ViewBag.Accounts = accounts;
            return View();
        }
    }
}
