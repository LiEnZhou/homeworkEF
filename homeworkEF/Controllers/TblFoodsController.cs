using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using homeworkEF.Models;

namespace homeworkEF.Controllers
{
    public class TblFoodsController : Controller
    {
        private readonly HomeworkDBContext _context;

        public TblFoodsController(HomeworkDBContext context)
        {
            _context = context;
        }

        // GET: TblFoods
        public async Task<IActionResult> Index()
        {
              return _context.TblFoods != null ? 
                          View(await _context.TblFoods.ToListAsync()) :
                          Problem("Entity set 'HomeworkDBContext.TblFoods'  is null.");
        }

        // GET: TblFoods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblFoods == null)
            {
                return NotFound();
            }

            var tblFood = await _context.TblFoods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblFood == null)
            {
                return NotFound();
            }

            return View(tblFood);
        }

        // GET: TblFoods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblFoods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Style,Starts,Price,Comment")] TblFood tblFood)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblFood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblFood);
        }

        // GET: TblFoods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblFoods == null)
            {
                return NotFound();
            }

            var tblFood = await _context.TblFoods.FindAsync(id);
            if (tblFood == null)
            {
                return NotFound();
            }
            return View(tblFood);
        }

        // POST: TblFoods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Style,Starts,Price,Comment")] TblFood tblFood)
        {
            if (id != tblFood.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblFood);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblFoodExists(tblFood.Id))
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
            return View(tblFood);
        }

        // GET: TblFoods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblFoods == null)
            {
                return NotFound();
            }

            var tblFood = await _context.TblFoods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblFood == null)
            {
                return NotFound();
            }

            return View(tblFood);
        }

        // POST: TblFoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblFoods == null)
            {
                return Problem("Entity set 'HomeworkDBContext.TblFoods'  is null.");
            }
            var tblFood = await _context.TblFoods.FindAsync(id);
            if (tblFood != null)
            {
                _context.TblFoods.Remove(tblFood);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblFoodExists(int id)
        {
          return (_context.TblFoods?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
