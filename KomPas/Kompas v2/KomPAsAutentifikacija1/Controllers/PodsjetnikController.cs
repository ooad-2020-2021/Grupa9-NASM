using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using KomPas.Models;
using KomPAsAutentifikacija1.Data;

namespace KomPas.Controllers
{
    public class PodsjetnikController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PodsjetnikController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Podsjetnik
        public async Task<IActionResult> Index()
        {
            return View(await _context.Podsjetnik.ToListAsync());
        }

        // GET: Podsjetnik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var podsjetnik = await _context.Podsjetnik
                .FirstOrDefaultAsync(m => m.PodsjetnikID == id);
            if (podsjetnik == null)
            {
                return NotFound();
            }

            return View(podsjetnik);
        }

        // GET: Podsjetnik/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Podsjetnik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PodsjetnikID,Tekst,Termin")] Podsjetnik podsjetnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(podsjetnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(podsjetnik);
        }

        // GET: Podsjetnik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var podsjetnik = await _context.Podsjetnik.FindAsync(id);
            if (podsjetnik == null)
            {
                return NotFound();
            }
            return View(podsjetnik);
        }

        // POST: Podsjetnik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PodsjetnikID,Tekst,Termin")] Podsjetnik podsjetnik)
        {
            if (id != podsjetnik.PodsjetnikID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(podsjetnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PodsjetnikExists(podsjetnik.PodsjetnikID))
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
            return View(podsjetnik);
        }

        // GET: Podsjetnik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var podsjetnik = await _context.Podsjetnik
                .FirstOrDefaultAsync(m => m.PodsjetnikID == id);
            if (podsjetnik == null)
            {
                return NotFound();
            }

            return View(podsjetnik);
        }

        // POST: Podsjetnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var podsjetnik = await _context.Podsjetnik.FindAsync(id);
            _context.Podsjetnik.Remove(podsjetnik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PodsjetnikExists(int id)
        {
            return _context.Podsjetnik.Any(e => e.PodsjetnikID == id);
        }
    }
}
