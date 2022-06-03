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
    public class TblFoodOrdersController : Controller
    {
        private readonly HomeworkDBContext _context;

        public TblFoodOrdersController(HomeworkDBContext context)
        {
            _context = context;
        }

        // GET: TblFoodOrders
        public async Task<IActionResult> Index()
        {
              return _context.TblFoodOrders != null ? 
                          View(await _context.TblFoodOrders.ToListAsync()) :
                          Problem("Entity set 'HomeworkDBContext.TblFoodOrders'  is null.");
        }

        // GET: TblFoodOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblFoodOrders == null)
            {
                return NotFound();
            }

            var tblFoodOrder = await _context.TblFoodOrders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblFoodOrder == null)
            {
                return NotFound();
            }

            return View(tblFoodOrder);
        }

        // GET: TblFoodOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblFoodOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,FoodId,OrderDateTime,PaidDateTime")] TblFoodOrder tblFoodOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblFoodOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblFoodOrder);
        }

        // GET: TblFoodOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblFoodOrders == null)
            {
                return NotFound();
            }

            var tblFoodOrder = await _context.TblFoodOrders.FindAsync(id);
            if (tblFoodOrder == null)
            {
                return NotFound();
            }
            return View(tblFoodOrder);
        }

        // POST: TblFoodOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,FoodId,OrderDateTime,PaidDateTime")] TblFoodOrder tblFoodOrder)
        {
            if (id != tblFoodOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblFoodOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblFoodOrderExists(tblFoodOrder.Id))
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
            return View(tblFoodOrder);
        }

        // GET: TblFoodOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblFoodOrders == null)
            {
                return NotFound();
            }

            var tblFoodOrder = await _context.TblFoodOrders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblFoodOrder == null)
            {
                return NotFound();
            }

            return View(tblFoodOrder);
        }

        // POST: TblFoodOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblFoodOrders == null)
            {
                return Problem("Entity set 'HomeworkDBContext.TblFoodOrders'  is null.");
            }
            var tblFoodOrder = await _context.TblFoodOrders.FindAsync(id);
            if (tblFoodOrder != null)
            {
                _context.TblFoodOrders.Remove(tblFoodOrder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblFoodOrderExists(int id)
        {
          return (_context.TblFoodOrders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
