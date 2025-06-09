using LpthLab08.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace LpthLab08.Controllers
{
    public class LpthAccountController : Controller
    {
        // GET: LpthAccountController
        public ActionResult LpthIndex()
        {
            // Khởi tạo danh sách tài khoản
            List<LpthAccount> accounts = new List<LpthAccount>
            {
                new LpthAccount
                {
                    LpthId = 1,
                    LpthFullName = "Le Phan Trung Hieu",
                    LpthEmail = "lephantrunghieu@gmail.com",
                    LpthPhone = "0901234567",
                    LpthAddress = "Hà Nội",
                    LpthAvatar = "avatar1.jpg",
                    LpthBirthday = new DateTime(2000, 1, 1),
                    LpthGender = "Nam",
                    LpthPassword = "123456",
                    LpthFacebook = "https://facebook.com/LePhanTrungHieu"
                },
                new LpthAccount
                {
                    LpthId = 2,
                    LpthFullName = "Trần Thị B",
                    LpthEmail = "b@gmail.com",
                    LpthPhone = "0912345678",
                    LpthAddress = "TP HCM",
                    LpthAvatar = "avatar2.jpg",
                    LpthBirthday = new DateTime(2001, 5, 15),
                    LpthGender = "Nữ",
                    LpthPassword = "abcdef",
                    LpthFacebook = "https://facebook.com/tranthib"
                },
                new LpthAccount
                {
                    LpthId = 3,
                    LpthFullName = "Lê Văn C",
                    LpthEmail = "c@gmail.com",
                    LpthPhone = "0923456789",
                    LpthAddress = "Đà Nẵng",
                    LpthAvatar = "avatar3.jpg",
                    LpthBirthday = new DateTime(1999, 12, 20),
                    LpthGender = "Nam",
                    LpthPassword = "pass123",
                    LpthFacebook = "https://facebook.com/levanc"
                },
                new LpthAccount
                {
                    LpthId = 4,
                    LpthFullName = "Phạm Thị D",
                    LpthEmail = "d@gmail.com",
                    LpthPhone = "0934567890",
                    LpthAddress = "Cần Thơ",
                    LpthAvatar = "avatar4.jpg",
                    LpthBirthday = new DateTime(2002, 3, 10),
                    LpthGender = "Nữ",
                    LpthPassword = "123abc",
                    LpthFacebook = "https://facebook.com/phamthid"
                },
                new LpthAccount
                {
                    LpthId = 5,
                    LpthFullName = "Đặng Văn E",
                    LpthEmail = "e@gmail.com",
                    LpthPhone = "0945678901",
                    LpthAddress = "Huế",
                    LpthAvatar = "avatar5.jpg",
                    LpthBirthday = new DateTime(1998, 7, 25),
                    LpthGender = "Nam",
                    LpthPassword = "mypassword",
                    LpthFacebook = "https://facebook.com/dangvane"
                }
            };

            return View(accounts);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult LpthCreate()
        {
            LpthAccount model= new LpthAccount();
            return View(model);
            return RedirectToAction(nameof(LpthIndex));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public IActionResult VerifyPhone(string LpthPhone)
        {
            // Hợp lệ: 0986421127 hoặc 098-642-1127 hoặc 098.642.1127
            Regex _isPhone = new Regex(@"^0\d{9}$|^0\d{2}[-. ]\d{3}[-. ]\d{4}$");

            if (!_isPhone.IsMatch(LpthPhone))
            {
                return Json($"Số điện thoại {LpthPhone} không đúng định dạng, VD: 0986421127 hoặc 098.642.1127");
            }

            return Json(true);
        }

    }
}
