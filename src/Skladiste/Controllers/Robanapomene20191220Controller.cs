using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Skladiste.Models;

namespace Skladiste.Controllers
{
    public class Robanapomene20191220Controller : Controller
    {
        private readonly RobaContext _context;

        public Robanapomene20191220Controller(RobaContext context)
        {
            _context = context;
        }

        // GET: Robanapomene20191220
        public async Task<IActionResult> Index()
        {
            var robaContext = _context.Robanapomene20191220.Include(r => r.IdRobaNavigation);
            return View(await robaContext.ToListAsync());
        }

        // GET: Robanapomene20191220/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var robanapomene20191220 = await _context.Robanapomene20191220
                .Include(r => r.IdRobaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (robanapomene20191220 == null)
            {
                return NotFound();
            }

            return View(robanapomene20191220);
        }

        // GET: Robanapomene20191220/Create
        public IActionResult Create()
        {
            ViewData["IdRoba"] = new SelectList(_context.Roba20191220, "IdRoba", "IdRoba");
            return View();
        }

        // POST: Robanapomene20191220/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdRoba,Napomena")] Robanapomene20191220 robanapomene20191220)
        {
            if (ModelState.IsValid)
            {
                _context.Add(robanapomene20191220);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRoba"] = new SelectList(_context.Roba20191220, "IdRoba", "IdRoba", robanapomene20191220.IdRoba);
            return View(robanapomene20191220);
        }

        // GET: Robanapomene20191220/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var robanapomene20191220 = await _context.Robanapomene20191220.FindAsync(id);
            if (robanapomene20191220 == null)
            {
                return NotFound();
            }
            ViewData["IdRoba"] = new SelectList(_context.Roba20191220, "IdRoba", "IdRoba", robanapomene20191220.IdRoba);
            return View(robanapomene20191220);
        }

        // POST: Robanapomene20191220/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdRoba,Napomena")] Robanapomene20191220 robanapomene20191220)
        {
            if (id != robanapomene20191220.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(robanapomene20191220);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Robanapomene20191220Exists(robanapomene20191220.Id))
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
            ViewData["IdRoba"] = new SelectList(_context.Roba20191220, "IdRoba", "IdRoba", robanapomene20191220.IdRoba);
            return View(robanapomene20191220);
        }

        // GET: Robanapomene20191220/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var robanapomene20191220 = await _context.Robanapomene20191220
                .Include(r => r.IdRobaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (robanapomene20191220 == null)
            {
                return NotFound();
            }

            return View(robanapomene20191220);
        }

        // POST: Robanapomene20191220/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var robanapomene20191220 = await _context.Robanapomene20191220.FindAsync(id);
            _context.Robanapomene20191220.Remove(robanapomene20191220);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Robanapomene20191220Exists(int id)
        {
            return _context.Robanapomene20191220.Any(e => e.Id == id);
        }
    }
}
