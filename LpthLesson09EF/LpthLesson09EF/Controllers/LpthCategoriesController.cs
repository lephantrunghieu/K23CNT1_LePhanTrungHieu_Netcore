using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LpthLesson09EF.Models;

namespace LpthLesson09EF.Controllers
{
    public class LpthCategoriesController : Controller
    {
        private readonly LpthBookStoreContext _context;

        public LpthCategoriesController(LpthBookStoreContext context)
        {
            _context = context;
        }

        // GET: LpthCategories
        public async Task<IActionResult> LpthIndex(string keyword)
        {
            var lpthCategories = from c in _context.Categories
                                 select c;

            if (!string.IsNullOrEmpty(keyword))
            {
                lpthCategories = lpthCategories.Where(c => c.CategoryName!.Contains(keyword));
            }

            return View(await lpthCategories.ToListAsync());
        }


        // GET: LpthCategories/Details/5
        public async Task<IActionResult> LpthDetails(int? lpthid)
        {
            if (lpthid == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == lpthid);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: LpthCategories/Create
        public IActionResult LpthCreate()
        {
            return View();
        }

        // POST: LpthCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LpthCreate([Bind("CategoryId,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(LpthIndex));
            }
            return View(category);
        }

        // GET: LpthCategories/Edit/5
        public async Task<IActionResult> LpthEdit(int? lpthId)
        {
            if (lpthId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(lpthId);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: LpthCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LpthEdit(int lpthId, [Bind("CategoryId,CategoryName")] Category category)
        {
            if (lpthId != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(LpthIndex));
            }
            return View(category);
        }

        // GET: LpthCategories/LpthDelete/5
        public async Task<IActionResult> LpthDelete(int? lpthid)
        {
            if (lpthid == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == lpthid);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: LpthCategories/LpthDelete/5
        [HttpPost, ActionName("LpthDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LpthDeleteConfirmed(int lpthid)
        {
            var category = await _context.Categories.FindAsync(lpthid);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(LpthIndex));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }
    }
}
