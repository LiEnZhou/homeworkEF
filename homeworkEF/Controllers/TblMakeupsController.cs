using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using homeworkEF.Models;
using homeworkEF.Models.ViewModel;

namespace homeworkEF.Controllers
{
    public class TblMakeupsController : Controller
    {
        private readonly HomeworkDBContext _context;

        public TblMakeupsController(HomeworkDBContext context)
        {
            _context = context;
        }

        // GET: TblMakeups
        public async Task<IActionResult> Index()
        {
              return _context.TblMakeups != null ? 
                          View(await _context.TblMakeups.ToListAsync()) :
                          Problem("Entity set 'HomeworkDBContext.TblMakeups'  is null.");
        }

        // GET: TblMakeups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblMakeups == null)
            {
                return NotFound();
            }

            var tblMakeup = await _context.TblMakeups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblMakeup == null)
            {
                return NotFound();
            }

            return View(tblMakeup);
        }

        // GET: TblMakeups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblMakeups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Color")] TblMakeup tblMakeup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblMakeup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblMakeup);
        }

        // GET: TblMakeups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblMakeups == null)
            {
                return NotFound();
            }

            var tblMakeup = await _context.TblMakeups.FindAsync(id);
            if (tblMakeup == null)
            {
                return NotFound();
            }
            return View(tblMakeup);
        }

        // POST: TblMakeups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Color")] TblMakeup tblMakeup)
        {
            if (id != tblMakeup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblMakeup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblMakeupExists(tblMakeup.Id))
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
            return View(tblMakeup);
        }

        // GET: TblMakeups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblMakeups == null)
            {
                return NotFound();
            }

            var tblMakeup = await _context.TblMakeups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblMakeup == null)
            {
                return NotFound();
            }

            return View(tblMakeup);
        }

        // POST: TblMakeups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblMakeups == null)
            {
                return Problem("Entity set 'HomeworkDBContext.TblMakeups'  is null.");
            }
            var tblMakeup = await _context.TblMakeups.FindAsync(id);
            if (tblMakeup != null)
            {
                _context.TblMakeups.Remove(tblMakeup);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblMakeupExists(int id)
        {
          return (_context.TblMakeups?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public IActionResult Search()
        {
            ViewData["Message"] = "Makeup =>取得表單";
            return View(new MakeupViewModel());
        }
        [HttpPost]
        public IActionResult Search(MakeupParams searchParams)
        {
            var viewModel = new MakeupViewModel();
            var searchResult = _context.TblMakeups.Where(x => x.Price >= searchParams.MinPrice && x.Price <= searchParams.MaxPrice);


            viewModel.SearchParams = searchParams;
            viewModel.Makeups = searchResult.ToList();
            ViewData["Message"] = $"找到{viewModel.Makeups.Count}個";

            return View(viewModel);
        }
    }
}
