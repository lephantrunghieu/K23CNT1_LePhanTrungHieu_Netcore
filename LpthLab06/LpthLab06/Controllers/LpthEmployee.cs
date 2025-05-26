using Microsoft.AspNetCore.Mvc;
using LpthLab06.Models;
using System;
using System.Collections.Generic;

namespace LpthLab06.Controllers
{
    public class LpthEmployeeController : Controller
    {
        // Tập dữ liệu nhân viên (giả lập trong bộ nhớ)
        public static List<LpthEmployee> lpthListEmployee = new List<LpthEmployee>()
        {
            new LpthEmployee { LpthId = 1, LpthName = "Lê Phan Trung Hiếu", LpthBirthDay = new DateTime(2003, 11, 4), LpthEmail = "lephantrunghieu@gmail.com", LpthPhone = "0123456886", LpthSalary = 1000, LpthStatus = true },
            new LpthEmployee { LpthId = 2, LpthName = "Long vip", LpthBirthDay = new DateTime(1992, 5, 20), LpthEmail = "b@example.com", LpthPhone = "0234567890", LpthSalary = 1200, LpthStatus = true },
            new LpthEmployee { LpthId = 3, LpthName = "Long mộng gà", LpthBirthDay = new DateTime(1995, 3, 15), LpthEmail = "c@example.com", LpthPhone = "0345678901", LpthSalary = 1100, LpthStatus = false },
            new LpthEmployee { LpthId = 4, LpthName = "Tú sena", LpthBirthDay = new DateTime(1998, 8, 10), LpthEmail = "d@example.com", LpthPhone = "0456789012", LpthSalary = 1300, LpthStatus = true },
            new LpthEmployee { LpthId = 5, LpthName = "Kayff", LpthBirthDay = new DateTime(2003, 9, 25), LpthEmail = "svx@student.edu", LpthPhone = "0567890123", LpthSalary = 0, LpthStatus = true }
        };

        // Action hiển thị danh sách nhân viên
        public IActionResult LpthEmployeeList()
        {
            return View(lpthListEmployee);
        }

        // Action GET: hiển thị form thêm mới nhân viên
        [HttpGet]
        public IActionResult LpthCreate()
        {
            return View();
        }

        // Action POST: xử lý thêm nhân viên mới
        [HttpPost]
        public IActionResult LpthCreateSubmit(LpthEmployee emp)
        {
            // Tự tăng Id (nếu cần)
            emp.LpthId = lpthListEmployee.Count + 1;

            lpthListEmployee.Add(emp);

            // Redirect về danh sách
            return RedirectToAction("LpthEmployeeList");
        }

        // GET: Hiển thị form sửa
        [HttpGet]
        public IActionResult LpthEdit(int id)
        {
            var emp = lpthListEmployee.FirstOrDefault(e => e.LpthId == id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        // POST: Cập nhật dữ liệu nhân viên
        [HttpPost]
        public IActionResult LpthEdit(LpthEmployee emp)
        {
            var existing = lpthListEmployee.FirstOrDefault(e => e.LpthId == emp.LpthId);
            if (existing == null) return NotFound();

            existing.LpthName = emp.LpthName;
            existing.LpthBirthDay = emp.LpthBirthDay;
            existing.LpthEmail = emp.LpthEmail;
            existing.LpthPhone = emp.LpthPhone;
            existing.LpthSalary = emp.LpthSalary;
            existing.LpthStatus = emp.LpthStatus;

            return RedirectToAction("LpthEmployeeList");
        }

        // GET: Xóa nhân viên
        [HttpGet]
        public IActionResult LpthDelete(int id)
        {
            var emp = lpthListEmployee.FirstOrDefault(e => e.LpthId == id);
            if (emp == null) return NotFound();

            lpthListEmployee.Remove(emp);
            return RedirectToAction("LpthEmployeeList");
        }
    }
}
