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
    public class ZahtjevZaUdomljavanjeController : Controller
    {
        private readonly KomPasContext _context;

        public ZahtjevZaUdomljavanjeController(KomPasContext context)
        {
            _context = context;
        }

        // GET: ZahtjevZaUdomljavanje
        public async Task<IActionResult> Index()
        {
            return View(await _context.ZahtjevZaUdomljavanje.ToListAsync());
        }

        // GET: ZahtjevZaUdomljavanje/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zahtjevZaUdomljavanje = await _context.ZahtjevZaUdomljavanje
                .FirstOrDefaultAsync(m => m.ZahtjevZaUdomljavanjeID == id);
            if (zahtjevZaUdomljavanje == null)
            {
                return NotFound();
            }

            return View(zahtjevZaUdomljavanje);
        }

        // GET: ZahtjevZaUdomljavanje/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ZahtjevZaUdomljavanje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZahtjevZaUdomljavanjeID,Grad,Adresa,ImaPsa")] ZahtjevZaUdomljavanje zahtjevZaUdomljavanje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zahtjevZaUdomljavanje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zahtjevZaUdomljavanje);
        }

        // GET: ZahtjevZaUdomljavanje/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zahtjevZaUdomljavanje = await _context.ZahtjevZaUdomljavanje.FindAsync(id);
            if (zahtjevZaUdomljavanje == null)
            {
                return NotFound();
            }
            return View(zahtjevZaUdomljavanje);
        }

        // POST: ZahtjevZaUdomljavanje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZahtjevZaUdomljavanjeID,Grad,Adresa,ImaPsa")] ZahtjevZaUdomljavanje zahtjevZaUdomljavanje)
        {
            if (id != zahtjevZaUdomljavanje.ZahtjevZaUdomljavanjeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zahtjevZaUdomljavanje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZahtjevZaUdomljavanjeExists(zahtjevZaUdomljavanje.ZahtjevZaUdomljavanjeID))
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
            return View(zahtjevZaUdomljavanje);
        }

        // GET: ZahtjevZaUdomljavanje/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zahtjevZaUdomljavanje = await _context.ZahtjevZaUdomljavanje
                .FirstOrDefaultAsync(m => m.ZahtjevZaUdomljavanjeID == id);
            if (zahtjevZaUdomljavanje == null)
            {
                return NotFound();
            }

            return View(zahtjevZaUdomljavanje);
        }

        // POST: ZahtjevZaUdomljavanje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zahtjevZaUdomljavanje = await _context.ZahtjevZaUdomljavanje.FindAsync(id);
            _context.ZahtjevZaUdomljavanje.Remove(zahtjevZaUdomljavanje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZahtjevZaUdomljavanjeExists(int id)
        {
            return _context.ZahtjevZaUdomljavanje.Any(e => e.ZahtjevZaUdomljavanjeID == id);
        }
    }
}
