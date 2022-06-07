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
    public class TblHeroesController : Controller
    {
        private readonly HomeworkDBContext _context;

        public TblHeroesController(HomeworkDBContext context)
        {
            _context = context;
        }

        // GET: TblHeroes
        public IActionResult Index()
        {
              return _context.TblHeroes != null ? 
                          View( _context.TblHeroes.ToList()) :
                          Problem("Entity set 'HomeworkDBContext.TblHeroes'  is null.");
        }

        // GET: TblHeroes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _context.TblHeroes == null)
            {
                return NotFound();
            }

            var tblHero =  _context.TblHeroes
                .FirstOrDefault(m => m.Id == id);
            if (tblHero == null)
            {
                return NotFound();
            }

            return View(tblHero);
        }

        // GET: TblHeroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblHeroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Atk,Hp")] TblHero tblHero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblHero);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tblHero);
        }

        // GET: TblHeroes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.TblHeroes == null)
            {
                return NotFound();
            }

            var tblHero =  _context.TblHeroes.Find(id);
            if (tblHero == null)
            {
                return NotFound();
            }
            return View(tblHero);
        }

        // POST: TblHeroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Atk,Hp")] TblHero tblHero)
        {
            if (id != tblHero.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblHero);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblHeroExists(tblHero.Id))
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
            return View(tblHero);
        }

        // GET: TblHeroes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || _context.TblHeroes == null)
            {
                return NotFound();
            }

            var tblHero =  _context.TblHeroes
                .FirstOrDefault(m => m.Id == id);
            if (tblHero == null)
            {
                return NotFound();
            }

            return View(tblHero);
        }

        // POST: TblHeroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_context.TblHeroes == null)
            {
                return Problem("Entity set 'HomeworkDBContext.TblHeroes'  is null.");
            }
            var tblHero =  _context.TblHeroes.Find(id);
            if (tblHero != null)
            {
                _context.TblHeroes.Remove(tblHero);
            }
            
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool TblHeroExists(int id)
        {
          return (_context.TblHeroes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
