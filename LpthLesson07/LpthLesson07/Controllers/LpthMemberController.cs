using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LpthLesson07.Controllers
{
    public class LpthMemberController : Controller
    {
        // GET: LpthMemberController
        public ActionResult LpthIndex()
        {
            return View();
        }

        // GET: LpthMemberController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LpthMemberController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LpthMemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(LpthIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: LpthMemberController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LpthMemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(LpthIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: LpthMemberController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LpthMemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(LpthIndex));
            }
            catch
            {
                return View();
            }
        }
    }
}
