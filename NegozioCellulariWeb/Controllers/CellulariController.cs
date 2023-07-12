using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.EntityFrameworkCore;
using NegozioCellulariWeb.Models;

namespace NegozioCellulariWeb.Controllers
{
    public class CellulariController : Controller
    {
        private readonly NegozioCellulariContext _context;

        public CellulariController(NegozioCellulariContext context)
        {
            _context = context;
        }

        // GET: Cellulari
        public async Task<IActionResult> Index()
        {
              return _context.Cellulari != null ? 
                          View(await _context.Cellulari.ToListAsync()) :
                          Problem("Entity set 'NegozioCellulariContext.Cellulari'  is null.");
        }

        // GET: Cellulari/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cellulari == null)
            {
                return NotFound();
            }

            var cellulare = await _context.Cellulari
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cellulare == null)
            {
                return NotFound();
            }

            return View(cellulare);
        }

        // GET: Cellulari/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cellulari/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cellulare cellulare)
        {
            if (ModelState.IsValid)
            {
                // Salvo il file
                // Dall'oggetto FileImmagine prendo il nome  e lo copio nella proprietà immagine
                // Devo però mettere un prefisso all'immagine, un qualcosa di casuale
                string nomeFile = Guid.NewGuid().ToString() + "_" + cellulare.FileImmagine.FileName;
                cellulare.NomeImmagine = nomeFile;
                _context.Add(cellulare);
                await _context.SaveChangesAsync();
                // Ho salvato la riga, ora devo salvare il file!
                string path = Directory.GetCurrentDirectory() + @"\wwwroot\immagini\" + nomeFile;
                // ma questa sopra non funziona sotto Linux!
                // La 'Combine' però aggancia le directory col giusto separatore, a second ase Linux  o Win
                string pathFile = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "immagini", nomeFile);
                var stream = new FileStream(pathFile, FileMode.Create);
                cellulare.FileImmagine.CopyTo(stream);
                stream.Close();

                return RedirectToAction(nameof(Index));
            }
            return View(cellulare);
        }

        // GET: Cellulari/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cellulari == null)
            {
                return NotFound();
            }

            var cellulare = await _context.Cellulari.FindAsync(id);
            if (cellulare == null)
            {
                return NotFound();
            }
            return View(cellulare);
        }

        // POST: Cellulari/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cellulare cellulare)
        {
            if (id != cellulare.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Ho scelto un immagine nuova? Se si, salvo al posto della vecchia
                    if(cellulare.FileImmagine != null)
                    {
                        // Cancello quella vecchia
                        string OldImg = Path.Combine(Directory.GetCurrentDirectory(),
                            "wwwroot", "immagini", cellulare.NomeImmagine);
                        System.IO.File.Delete(OldImg);
                        // Sostituisco quella nuova
                        string nomeFile = Guid.NewGuid().ToString() + "_" + cellulare.FileImmagine.FileName;
                        cellulare.NomeImmagine = nomeFile;
                        string pathFile = Path.Combine(Directory.GetCurrentDirectory(),
                            "wwwroot", "immagini", nomeFile);
                        var stream = new FileStream(pathFile, FileMode.Create);
                        cellulare.FileImmagine.CopyTo(stream);
                        stream.Close();
                    }
                    _context.Update(cellulare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CellulareExists(cellulare.Id))
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
            return View(cellulare);
        }

        // GET: Cellulari/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cellulari == null)
            {
                return NotFound();
            }

            var cellulare = await _context.Cellulari
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cellulare == null)
            {
                return NotFound();
            }

            return View(cellulare);
        }

        // POST: Cellulari/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cellulari == null)
            {
                return Problem("Entity set 'NegozioCellulariContext.Cellulari'  is null.");
            }
            var cellulare = await _context.Cellulari.FindAsync(id);
            if (cellulare != null)
            {
                _context.Cellulari.Remove(cellulare);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CellulareExists(int id)
        {
          return (_context.Cellulari?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
