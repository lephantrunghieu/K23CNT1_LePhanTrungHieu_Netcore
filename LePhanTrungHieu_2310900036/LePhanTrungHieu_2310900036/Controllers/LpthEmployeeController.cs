using LePhanTrungHieu_2310900036.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class LpthEmployeeController : Controller
{
    private readonly LePhanTrungHieu2310900036Context _context;

    public LpthEmployeeController(LePhanTrungHieu2310900036Context context)
    {
        _context = context;
    }

    // GET: LpthEmployees/LpthIndex
    public async Task<IActionResult> LpthIndex()
    {
        return View(await _context.LpthEmployees.ToListAsync());
    }

    // GET: LpthEmployees/LpthDetails/5
    public async Task<IActionResult> LpthDetails(int? id)
    {
        if (id == null) return NotFound();

        var lpthEmployee = await _context.LpthEmployees.FirstOrDefaultAsync(m => m.LpthEmpId == id);
        if (lpthEmployee == null) return NotFound();

        return View(lpthEmployee);
    }

    // GET: LpthEmployees/LpthCreate
    public IActionResult LpthCreate()
    {
        return View();
    }

    // POST: LpthEmployees/LpthCreate
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LpthCreate([Bind("LpthEmpId,LpthEmpName,LpthEmpLevel,LpthEmpStartDate,LpthEmpStatus")] LpthEmployee lpthEmployee)
    {
        if (ModelState.IsValid)
        {
            _context.Add(lpthEmployee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(LpthIndex));
        }
        return View(lpthEmployee);
    }

    // GET: LpthEmployees/LpthEdit/5
    public async Task<IActionResult> LpthEdit(int? id)
    {
        if (id == null) return NotFound();

        var lpthEmployee = await _context.LpthEmployees.FindAsync(id);
        if (lpthEmployee == null) return NotFound();

        return View(lpthEmployee);
    }

    // POST: LpthEmployees/LpthEdit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LpthEdit(int id, [Bind("LpthEmpId,LpthEmpName,LpthEmpLevel,LpthEmpStartDate,LpthEmpStatus")] LpthEmployee lpthEmployee)
    {
        if (id != lpthEmployee.LpthEmpId) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(lpthEmployee);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LpthEmployeeExists(lpthEmployee.LpthEmpId)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(LpthIndex));
        }
        return View(lpthEmployee);
    }

    // GET: LpthEmployees/LpthDelete/5
    public async Task<IActionResult> LpthDelete(int? id)
    {
        if (id == null) return NotFound();

        var lpthEmployee = await _context.LpthEmployees.FirstOrDefaultAsync(m => m.LpthEmpId == id);
        if (lpthEmployee == null) return NotFound();

        return View(lpthEmployee);
    }

    // POST: LpthEmployees/LpthDelete/5
    [HttpPost, ActionName("LpthDelete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LpthDeleteConfirmed(int id)
    {
        var lpthEmployee = await _context.LpthEmployees.FindAsync(id);
        if (lpthEmployee != null)
        {
            _context.LpthEmployees.Remove(lpthEmployee);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(LpthIndex));
    }

    private bool LpthEmployeeExists(int id)
    {
        return _context.LpthEmployees.Any(e => e.LpthEmpId == id);
    }
}
