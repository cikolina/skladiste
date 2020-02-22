using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skladiste.Models;

namespace Skladiste.Controllers
{
    public class BindingController : Controller
    {
        private readonly RobaContext _context;

        public BindingController(RobaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var binding = _context.Roba20191220.Join(
                _context.Robanapomene20191220,
                roba => roba.IdRoba,
                napomena => napomena.IdRoba,
                (roba, napomena) => new { roba, napomena }
                ).
                Select(x => new Test
                {
                    Roba = x.roba,
                    Napomena = x.napomena
                });

            return View(binding.ToList());
        }

        public async Task<IActionResult> Edit(int? robaId, int? napomenaId)
        {
            if (robaId == null || napomenaId == null)
            {
                return NotFound();
            }
            var binding = _context.Roba20191220.Join(
                _context.Robanapomene20191220,
                roba => roba.IdRoba,
                napomena => napomena.IdRoba,
                (roba, napomena) => new { roba, napomena }
                )
                .Where(r => r.roba.IdRoba == robaId && r.napomena.Id == napomenaId)
                .Select(x => new Test
                {
                    Roba = x.roba,
                    Napomena = x.napomena
                });

            if (binding == null)
            {
                return NotFound();
            }

            return View(binding.FirstOrDefault());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int robaId, int napomenaId, Test test)
        {
            if (robaId != test.Roba.IdRoba || napomenaId != test.Napomena.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var roba = _context.Roba20191220.Find(robaId);
                    var napomena = _context.Robanapomene20191220.Find(napomenaId);

                    roba.SifraProizvoda = test.Roba.SifraProizvoda;
                    roba.Status = test.Roba.Status;
                    roba.Tezina = test.Roba.Tezina;
                    roba.DatumIsporuke = test.Roba.DatumIsporuke;

                    napomena.Napomena = test.Napomena.Napomena;

                    _context.Update(roba);
                    _context.Update(napomena);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("Index","Binding");
            }
            return View(test);
        }

        public async Task<IActionResult> Delete(int? robaId, int? napomenaId)
        {
            if (robaId == null || napomenaId == null)
            {
                return NotFound();
            }

            var binding = _context.Roba20191220.Join(
                _context.Robanapomene20191220,
                roba => roba.IdRoba,
                napomena => napomena.IdRoba,
                (roba, napomena) => new { roba, napomena }
                )
                .Where(r => r.roba.IdRoba == robaId && r.napomena.Id == napomenaId)
                .Select(x => new Test
                {
                    Roba = x.roba,
                    Napomena = x.napomena
                });

            if (binding == null)
            {
                return NotFound();
            }

            return View(binding.FirstOrDefault());
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int robaId, int napomenaId)
        {

            var roba = await _context.Roba20191220.FindAsync(robaId);
            var napomena = await _context.Robanapomene20191220.FindAsync(napomenaId);

            _context.Robanapomene20191220.Remove(napomena);
            await _context.SaveChangesAsync();

            _context.Roba20191220.Remove(roba);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}