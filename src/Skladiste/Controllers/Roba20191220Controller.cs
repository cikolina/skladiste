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
    public class Roba20191220Controller : Controller
    {
        private readonly RobaContext _context;

        public Roba20191220Controller(RobaContext context)
        {
            _context = context;
        }

        // GET: Roba20191220
        public async Task<IActionResult> Index()
        {
            return View(await _context.Roba20191220.ToListAsync());
        }

        // GET: Roba20191220/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roba20191220 = await _context.Roba20191220
                .FirstOrDefaultAsync(m => m.IdRoba == id);
            if (roba20191220 == null)
            {
                return NotFound();
            }

            return View(roba20191220);
        }

        // GET: Roba20191220/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roba20191220/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRoba,SifraProizvoda,Status,Tezina,DatumIsporuke")] Roba20191220 roba20191220)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roba20191220);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roba20191220);
        }

        // GET: Roba20191220/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roba20191220 = await _context.Roba20191220.FindAsync(id);
            if (roba20191220 == null)
            {
                return NotFound();
            }
            return View(roba20191220);
        }

        // POST: Roba20191220/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRoba,SifraProizvoda,Status,Tezina,DatumIsporuke")] Roba20191220 roba20191220)
        {
            if (id != roba20191220.IdRoba)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roba20191220);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Roba20191220Exists(roba20191220.IdRoba))
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
            return View(roba20191220);
        }

        // GET: Roba20191220/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roba20191220 = await _context.Roba20191220
                .FirstOrDefaultAsync(m => m.IdRoba == id);
            if (roba20191220 == null)
            {
                return NotFound();
            }

            return View(roba20191220);
        }

        // POST: Roba20191220/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roba20191220 = await _context.Roba20191220.FindAsync(id);
            _context.Roba20191220.Remove(roba20191220);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Roba20191220Exists(int id)
        {
            return _context.Roba20191220.Any(e => e.IdRoba == id);
        }
    }
}
