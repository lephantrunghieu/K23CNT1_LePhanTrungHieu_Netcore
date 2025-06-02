using Microsoft.AspNetCore.Mvc;
using LpthLesson07.Models;

namespace LpthLesson07.Controllers
{
    public class LpthEmployeeController : Controller
    {
        private static List<LpthEmployee> lpthListEmployees = new List<LpthEmployee>
        {
            new LpthEmployee { LpthId = 230001122, LpthName = "Le Phan Trung Hieu", LpthBirthDay = new DateTime(2003, 11, 04), LpthEmail = "lehieu@gmail.com", LpthPhone = "0978611889", LpthSalary = 12000000, LpthStatus = true },
            new LpthEmployee { LpthId = 2, LpthName = "Trần Thị B", LpthBirthDay = new DateTime(1992, 5, 15), LpthEmail = "b@example.com", LpthPhone = "0912233445", LpthSalary = 15000000, LpthStatus = true },
            new LpthEmployee { LpthId = 3, LpthName = "Lê Văn C", LpthBirthDay = new DateTime(1988, 9, 20), LpthEmail = "c@example.com", LpthPhone = "0922123456", LpthSalary = 11000000, LpthStatus = false },
            new LpthEmployee { LpthId = 4, LpthName = "Phạm Thị D", LpthBirthDay = new DateTime(1995, 3, 10), LpthEmail = "d@example.com", LpthPhone = "0933445566", LpthSalary = 13000000, LpthStatus = true },
            new LpthEmployee { LpthId = 5, LpthName = "Đỗ Văn E", LpthBirthDay = new DateTime(1991, 7, 25), LpthEmail = "e@example.com", LpthPhone = "0944567890", LpthSalary = 10000000, LpthStatus = false }
        };

        public IActionResult LpthIndex()
        {
            return View(lpthListEmployees);
        }

        // GET: /LpthEmployee/LpthCreate
        public IActionResult LpthCreate()
        {
            var lpthModel = new LpthEmployee();
            return View(lpthModel);
        }

        // POST: /LpthEmployee/LpthCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LpthCreate(LpthEmployee lpthModel)
        {
            try
            {
                // Tự động sinh mã nếu cần
                if (lpthModel.LpthId == 0)
                {
                    lpthModel.LpthId = lpthListEmployees.Max(e => e.LpthId) + 1;
                }
                lpthListEmployees.Add(lpthModel);
                return RedirectToAction(nameof(LpthIndex));
            }
            catch
            {
                return View();
            }
        }

        //  GET: /LpthEmployee/LpthEdit/5
        public IActionResult LpthEdit(int id)
        {
            var lpthModel = lpthListEmployees.FirstOrDefault(x => x.LpthId == id);
            return View(lpthModel);
        }

        // POST: LpthEmployee/LpthEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LpthEdit(int id, LpthEmployee lpthModel)
        {
            try
            {
                for (int i = 0; i < lpthListEmployees.Count; i++)
                {
                    if (lpthListEmployees[i].LpthId == id)
                    {
                        lpthListEmployees[i] = lpthModel;
                        break;
                    }
                }
                return RedirectToAction(nameof(LpthIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: LpthEmployee/LpthDetails/5
        public ActionResult LpthDetails(int id)
        {
            var lpthModel = lpthListEmployees.FirstOrDefault(x => x.LpthId == id);
            return View(lpthModel);
        }

        // GET: LpthEmployee/LpthDelete/5
        public ActionResult LpthDelete(int id)
        {
            var lpthModel = lpthListEmployees.FirstOrDefault(x => x.LpthId == id);
            return View(lpthModel);
        }

        // POST: LpthEmployee/LpthDelete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LpthDelete(int id, LpthEmployee lpthModel)
        {
            try
            {
                for (int i = 0; i < lpthListEmployees.Count; i++)
                {
                    if (lpthListEmployees[i].LpthId == id)
                    {
                        lpthListEmployees.RemoveAt(i);
                        break;
                    }
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
