using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibriController : ControllerBase
    {
        private readonly BibliotecaDbContext _context;

        public LibriController(BibliotecaDbContext context)
        {
            _context = context;
        }

        // GET: api/Libri
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libri>>> GetLibris()
        {
          if (_context.Libris == null)
          {
              return NotFound();
          }
            return await _context.Libris.ToListAsync();
        }

        // GET: api/Libri/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Libri>> GetLibri(int id)
        {
          if (_context.Libris == null)
          {
              return NotFound();
          }
            var libri = await _context.Libris.FindAsync(id);

            if (libri == null)
            {
                return NotFound();
            }

            return libri;
        }

        // PUT: api/Libri/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibri(int id, Libri libri)
        {
            if (id != libri.Id)
            {
                return BadRequest();
            }

            _context.Entry(libri).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibriExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Libri
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Libri>> PostLibri(Libri libri)
        {
          if (_context.Libris == null)
          {
              return Problem("Entity set 'BibliotecaDbContext.Libris'  is null.");
          }
            _context.Libris.Add(libri);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibri", new { id = libri.Id }, libri);
        }

        // DELETE: api/Libri/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibri(int id)
        {
            if (_context.Libris == null)
            {
                return NotFound();
            }
            var libri = await _context.Libris.FindAsync(id);
            if (libri == null)
            {
                return NotFound();
            }

            _context.Libris.Remove(libri);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LibriExists(int id)
        {
            return (_context.Libris?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
