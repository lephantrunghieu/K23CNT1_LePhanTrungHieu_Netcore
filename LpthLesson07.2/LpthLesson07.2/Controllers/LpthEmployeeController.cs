using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LpthLesson07._2.Models;
namespace LpthLesson07._2.Controllers
{
    public class LpthEmployeeController : Controller
    {
        //mock data:
        private static List<LpthEmployee> lpthListEmployee = new List<LpthEmployee>()
        {
            new LpthEmployee
            {
                LpthId = 1,
                LpthName = "Le Phan Trung Hieu",
                LpthBirthDay = new DateTime(1990, 5, 10),
                LpthEmail = "nguyenvana@example.com",
                LpthPhone = "0901234567",
                LpthSalary = 12000000,
                LpthStatus = true
            },
            new LpthEmployee
            {
                LpthId = 2,
                LpthName = "Tran Thi B",
                LpthBirthDay = new DateTime(1992, 8, 15),
                LpthEmail = "tranthib@example.com",
                LpthPhone = "0912345678",
                LpthSalary = 13500000,
                LpthStatus = true
            },
            new LpthEmployee
            {
                LpthId = 3,
                LpthName = "Le Van C",
                LpthBirthDay = new DateTime(1988, 3, 22),
                LpthEmail = "levanc@example.com",
                LpthPhone = "0934567890",
                LpthSalary = 14000000,
                LpthStatus = false
            },
            new LpthEmployee
            {
                LpthId = 4,
                LpthName = "Pham Thi D",
                LpthBirthDay = new DateTime(1995, 11, 5),
                LpthEmail = "phamthid@example.com",
                LpthPhone = "0945678901",
                LpthSalary = 15000000,
                LpthStatus = true
            },
            new LpthEmployee
            {
                LpthId = 5,
                LpthName = "Hoang Van E",
                LpthBirthDay = new DateTime(1993, 9, 25),
                LpthEmail = "hoangvane@example.com",
                LpthPhone = "0956789012",
                LpthSalary = 12500000,
                LpthStatus = false
            }
        };

        // GET: LpthEmployeeController
        public ActionResult LpthIndex()
        {
            return View(lpthListEmployee);
        }

        // GET: LpthEmployeeController/LpthDetails/5
        public ActionResult LpthDetails(int id)
        {
            var lpthEmployee = lpthListEmployee.FirstOrDefault(x => x.LpthId == id);
            return View(lpthEmployee);
        }

        // GET: LpthEmployeeController/LpthCreate
        public ActionResult LpthCreate()
        {
            var lpthEmployee = new LpthEmployee();
            return View(lpthEmployee);
        }

        // POST: LpthEmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LpthCreate(LpthEmployee lpthModel)
        {
            try
            {
                //them moi nhan vien vao list
                lpthModel.LpthId = lpthListEmployee.Max(x => x.LpthId) + 1;
                lpthListEmployee.Add(lpthModel);
                return RedirectToAction(nameof(LpthIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: LpthEmployeeController/LpthEdit/5
        public ActionResult LpthEdit(int id)
        {
            var lpthEmployee = lpthListEmployee.FirstOrDefault(x=>x.LpthId == id);
            return View();
        }

        // POST: LpthEmployeeController/LpthEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LpthEdit(int id, LpthEmployee lpthModel)
        {
            try
            {
                for (int i = 0; i < lpthListEmployee.Count(); i++)
                {
                    if (lpthListEmployee[i].LpthId == id)
                    {
                        lpthListEmployee[i] = lpthModel;
                        break;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LpthEmployeeController/LpthDelete/5
        public ActionResult LpthDelete(int id)
        {
            var lpthEmployee = lpthListEmployee.FirstOrDefault(x => x.LpthId == id);
            if (lpthEmployee == null)
            {
                return NotFound();
            }
            return View(lpthEmployee);
        }

        // POST: LpthEmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LpthDelete(int id, IFormCollection collection)
        {
            try
            {
                var lpthEmployee = lpthListEmployee.FirstOrDefault(x => x.LpthId == id);
                if (lpthEmployee != null)
                {
                    lpthListEmployee.Remove(lpthEmployee);
                }
                return RedirectToAction(nameof(LpthIndex));
            }
            catch
            {
                return View();
            }
        }
    }
}
