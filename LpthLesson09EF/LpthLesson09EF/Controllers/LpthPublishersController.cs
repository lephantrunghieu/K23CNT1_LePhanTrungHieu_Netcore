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
    public class LpthPublishersController : Controller
    {
        private readonly LpthBookStoreContext _context;

        public LpthPublishersController(LpthBookStoreContext context)
        {
            _context = context;
        }

        // GET: LpthPublishers
        public async Task<IActionResult> LpthIndex(string keyword)
        {
            ViewBag.Keyword = keyword; // Trả lại từ khóa cho View để hiển thị lại trong ô input

            var lpthPublishers = from p in _context.Publishers
                                 select p;

            if (!string.IsNullOrEmpty(keyword))
            {
                lpthPublishers = lpthPublishers.Where(p => p.PublisherName!.Contains(keyword));
            }

            return View(await lpthPublishers.ToListAsync());
        }

        // GET: LpthPublishers/LpthDetails/5
        public async Task<IActionResult> LpthDetails(int? lpthid)
        {
            if (lpthid == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers
                .FirstOrDefaultAsync(m => m.PublisherId == lpthid);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // GET: LpthPublishers/LpthCreate
        public IActionResult LpthCreate()
        {
            return View();
        }

        // POST: LpthPublishers/LpthCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LpthCreate([Bind("PublisherId,PublisherName,Phone,Address")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publisher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(LpthIndex));
            }
            return View(publisher);
        }

        // GET: LpthPublishers/LpthEdit/5
        public async Task<IActionResult> LpthEdit(int? lpthid)
        {
            if (lpthid == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers.FindAsync(lpthid);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }

        // POST: LpthPublishers/LpthEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LpthEdit(int lpthid, [Bind("PublisherId,PublisherName,Phone,Address")] Publisher publisher)
        {
            if (lpthid != publisher.PublisherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publisher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublisherExists(publisher.PublisherId))
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
            return View(publisher);
        }

        // GET: LpthPublishers/LpthDelete/5
        public async Task<IActionResult> LpthDelete(int? lpthid)
        {
            if (lpthid == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers
                .FirstOrDefaultAsync(m => m.PublisherId == lpthid);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // POST: LpthPublishers/LpthDeleteConfirmed/5
        [HttpPost, ActionName("LpthDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LpthDeleteConfirmed(int lpthid)
        {
            var publisher = await _context.Publishers.FindAsync(lpthid);
            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(LpthIndex));
        }

        private bool PublisherExists(int id)
        {
            return _context.Publishers.Any(e => e.PublisherId == id);
        }
    }
}
