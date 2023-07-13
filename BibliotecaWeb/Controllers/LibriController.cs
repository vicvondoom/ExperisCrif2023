using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaWeb.Models;
using ReflectionIT.Mvc.Paging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BibliotecaWeb.Controllers
{
    public class LibriController : Controller
    {
        private readonly BiblioContext _context;

        public LibriController(BiblioContext context)
        {
            _context = context;
        }

        // GET: Libri
        public async Task<IActionResult> Index(int pageindex = 1, string sortExpression = "Titolo")
        {
            // Non fà una inner join, ma usa Include per caricare i dati dell'autore e dell'editore per ogni libro
            var query = _context.Libri.Include(l => l.Autore).Include(l => l.Editore);
            var model = PagingList.Create(query, 5, pageindex, sortExpression, "Titolo"); // 5 = righe da visualizzare
            
            return View(model);
        }

        // GET: Libri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Libri == null)
            {
                return NotFound();
            }

            var libro = await _context.Libri
                .Include(l => l.Autore)
                .Include(l => l.Editore)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libri/Create
        public IActionResult Create()
        {
            ViewData["IdAutore"] = new SelectList(_context.Autori, "Id", "Cognome");
            ViewData["IdEditore"] = new SelectList(_context.Editori, "Id", "Descrizione");
            return View();
        }

        // POST: Libri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titolo,Prezzo,IdAutore,IdEditore")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAutore"] = new SelectList(_context.Autori, "Id", "Cognome", libro.IdAutore);
            ViewData["IdEditore"] = new SelectList(_context.Editori, "Id", "Descrizione", libro.IdEditore);
            return View(libro);
        }

        // GET: Libri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Libri == null)
            {
                return NotFound();
            }

            var libro = await _context.Libri.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            ViewData["IdAutore"] = new SelectList(_context.Autori, "Id", "Cognome", libro.IdAutore);
            ViewData["IdEditore"] = new SelectList(_context.Editori, "Id", "Descrizione", libro.IdEditore);
            return View(libro);
        }

        // POST: Libri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titolo,Prezzo,IdAutore,IdEditore")] Libro libro)
        {
            if (id != libro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.Id))
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
            ViewData["IdAutore"] = new SelectList(_context.Autori, "Id", "Cognome", libro.IdAutore);
            ViewData["IdEditore"] = new SelectList(_context.Editori, "Id", "Descrizione", libro.IdEditore);
            return View(libro);
        }

        // GET: Libri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Libri == null)
            {
                return NotFound();
            }

            var libro = await _context.Libri
                .Include(l => l.Autore)
                .Include(l => l.Editore)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Libri == null)
            {
                return Problem("Entity set 'BiblioContext.Libri'  is null.");
            }
            var libro = await _context.Libri.FindAsync(id);
            if (libro != null)
            {
                _context.Libri.Remove(libro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
          return (_context.Libri?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
