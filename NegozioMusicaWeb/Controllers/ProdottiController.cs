using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NegozioMusicaWeb.Models;

namespace NegozioMusicaWeb.Controllers
{
    public class ProdottiController : Controller
    {
        private readonly MusicaContext _context;

        public ProdottiController(MusicaContext context)
        {
            _context = context;
        }

        //// Versione sincrona
        //public IActionResult Index()
        //{
        //    return View(_context.Prodotti.ToList());
        //}
        // GET: Prodotti
        public async Task<IActionResult> Index()
        {
              return _context.Prodotti != null ? 
                          View(await _context.Prodotti.ToListAsync()) :
                          Problem("Entity set 'MusicaContext.Prodotti'  is null.");
        }

        // GET: Prodotti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prodotti == null)
            {
                return NotFound();
            }

            var prodotto = await _context.Prodotti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prodotto == null)
            {
                return NotFound();
            }

            return View(prodotto);
        }

        // GET: Prodotti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prodotti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titolo,Artista,AnnoUscita")] Prodotto prodotto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prodotto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prodotto);
        }

        // GET: Prodotti/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prodotti == null)
            {
                return NotFound();
            }

            var prodotto = await _context.Prodotti.FindAsync(id);
            if (prodotto == null)
            {
                return NotFound();
            }
            return View(prodotto);
        }

        // POST: Prodotti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titolo,Artista,AnnoUscita")] Prodotto prodotto)
        {
            if (id != prodotto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prodotto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdottoExists(prodotto.Id))
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
            return View(prodotto);
        }

        // GET: Prodotti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prodotti == null)
            {
                return NotFound();
            }

            var prodotto = await _context.Prodotti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prodotto == null)
            {
                return NotFound();
            }

            return View(prodotto);
        }

        // POST: Prodotti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prodotti == null)
            {
                return Problem("Entity set 'MusicaContext.Prodotti'  is null.");
            }
            var prodotto = await _context.Prodotti.FindAsync(id);
            if (prodotto != null)
            {
                _context.Prodotti.Remove(prodotto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdottoExists(int id)
        {
          return (_context.Prodotti?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
