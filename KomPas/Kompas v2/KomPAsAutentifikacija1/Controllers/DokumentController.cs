using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KomPAsAutentifikacija1.Data;
using KomPas.Models;


namespace KomPas.Controllers
{
    public class DokumentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DokumentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dokument
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dokument.ToListAsync());
        }

        // GET: Dokument/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dokument = await _context.Dokument
                .FirstOrDefaultAsync(m => m.DokumentID == id);
            if (dokument == null)
            {
                return NotFound();
            }

            return View(dokument);
        }

        // GET: Dokument/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dokument/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DokumentID,Datoteka")] Dokument dokument)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dokument);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dokument);
        }

        // GET: Dokument/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dokument = await _context.Dokument.FindAsync(id);
            if (dokument == null)
            {
                return NotFound();
            }
            return View(dokument);
        }

        // POST: Dokument/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DokumentID,Datoteka")] Dokument dokument)
        {
            if (id != dokument.DokumentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dokument);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DokumentExists(dokument.DokumentID))
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
            return View(dokument);
        }

        // GET: Dokument/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dokument = await _context.Dokument
                .FirstOrDefaultAsync(m => m.DokumentID == id);
            if (dokument == null)
            {
                return NotFound();
            }

            return View(dokument);
        }

        // POST: Dokument/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dokument = await _context.Dokument.FindAsync(id);
            _context.Dokument.Remove(dokument);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DokumentExists(int id)
        {
            return _context.Dokument.Any(e => e.DokumentID == id);
        }
    }
}
