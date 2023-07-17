using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomIdentity.Data;

namespace CustomIdentity.Controllers
{
    public class OrdiniController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdiniController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ordini
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ordini.Include(o => o.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ordini/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ordini == null)
            {
                return NotFound();
            }

            var ordine = await _context.Ordini
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordine == null)
            {
                return NotFound();
            }

            return View(ordine);
        }

        // GET: Ordini/Create
        public IActionResult Create()
        {
            ViewData["IdUser"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Ordini/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descrizione,Prezzo,IdUser")] Ordine ordine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUser"] = new SelectList(_context.Users, "Id", "Id", ordine.IdUser);
            return View(ordine);
        }

        // GET: Ordini/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ordini == null)
            {
                return NotFound();
            }

            var ordine = await _context.Ordini.FindAsync(id);
            if (ordine == null)
            {
                return NotFound();
            }
            ViewData["IdUser"] = new SelectList(_context.Users, "Id", "Id", ordine.IdUser);
            return View(ordine);
        }

        // POST: Ordini/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descrizione,Prezzo,IdUser")] Ordine ordine)
        {
            if (id != ordine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdineExists(ordine.Id))
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
            ViewData["IdUser"] = new SelectList(_context.Users, "Id", "Id", ordine.IdUser);
            return View(ordine);
        }

        // GET: Ordini/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ordini == null)
            {
                return NotFound();
            }

            var ordine = await _context.Ordini
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordine == null)
            {
                return NotFound();
            }

            return View(ordine);
        }

        // POST: Ordini/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ordini == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Ordini'  is null.");
            }
            var ordine = await _context.Ordini.FindAsync(id);
            if (ordine != null)
            {
                _context.Ordini.Remove(ordine);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdineExists(int id)
        {
          return (_context.Ordini?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
