using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KomPas.Data;
using KomPas.Models;

namespace KomPas.Controllers
{
    public class PasController : Controller
    {
        private readonly KomPasContext _context;

        public PasController(KomPasContext context)
        {
            _context = context;
        }

        // GET: Pas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pas.ToListAsync());
        }

        // GET: Pas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pas = await _context.Pas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pas == null)
            {
                return NotFound();
            }

            return View(pas);
        }

        // GET: Pas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ime,Spol,Rasa,Tezina,ZdravstveniProblem,KastriranSterilisan,Slika")] Pas pas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pas);
        }

        // GET: Pas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pas = await _context.Pas.FindAsync(id);
            if (pas == null)
            {
                return NotFound();
            }
            return View(pas);
        }

        // POST: Pas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ime,Spol,Rasa,Tezina,ZdravstveniProblem,KastriranSterilisan,Slika")] Pas pas)
        {
            if (id != pas.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PasExists(pas.ID))
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
            return View(pas);
        }

        // GET: Pas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pas = await _context.Pas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pas == null)
            {
                return NotFound();
            }

            return View(pas);
        }

        // POST: Pas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pas = await _context.Pas.FindAsync(id);
            _context.Pas.Remove(pas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PasExists(int id)
        {
            return _context.Pas.Any(e => e.ID == id);
        }
    }
}
