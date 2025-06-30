using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LpthLesson10.Models;

namespace LpthLesson10.Controllers
{
    public class LpthPostsController : Controller
    {
        private readonly LpthK23cnt1Lesson10DbContext _context;

        public LpthPostsController(LpthK23cnt1Lesson10DbContext context)
        {
            _context = context;
        }

        // GET: LpthPosts
        public async Task<IActionResult> LpthIndex()
        {
            return View(await _context.LpthPosts.ToListAsync());
        }

        // GET: LpthPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lpthPost = await _context.LpthPosts
                .FirstOrDefaultAsync(m => m.LpthId == id);
            if (lpthPost == null)
            {
                return NotFound();
            }

            return View(lpthPost);
        }

        // GET: LpthPosts/Create
        public IActionResult LpthCreate()
        {
            return View();
        }

        // POST: LpthPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LpthId,LpthTitle,LpthImage,LpthContent,LpthStatus")] LpthPost lpthPost)
        {
            if (id != lpthPost.LpthId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lpthPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LpthPostExists(lpthPost.LpthId))
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
            return View(lpthPost);
        }

        // GET: LpthPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lpthPost = await _context.LpthPosts.FindAsync(id);
            if (lpthPost == null)
            {
                return NotFound();
            }
            return View(lpthPost);
        }

        // POST: LpthPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LpthEdit(int id, [Bind("LpthId,LpthTitle,LpthImage,LpthContent,LpthStatus")] LpthPost lpthPost)
        {
            if (id != lpthPost.LpthId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lpthPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LpthPostExists(lpthPost.LpthId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(lpthPost);
        }

        // GET: LpthPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lpthPost = await _context.LpthPosts
                .FirstOrDefaultAsync(m => m.LpthId == id);
            if (lpthPost == null)
            {
                return NotFound();
            }

            return View(lpthPost);
        }

        // POST: LpthPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lpthPost = await _context.LpthPosts.FindAsync(id);
            if (lpthPost != null)
            {
                _context.LpthPosts.Remove(lpthPost);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LpthPostExists(int id)
        {
            return _context.LpthPosts.Any(e => e.LpthId == id);
        }
    }
}
