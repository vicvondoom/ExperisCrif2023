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
    public class AutoriController : ControllerBase
    {
        private readonly BibliotecaDbContext _context;

        public AutoriController(BibliotecaDbContext context)
        {
            _context = context;
        }

        // GET: api/Autori
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autori>>> GetAutoris()
        {
          if (_context.Autoris == null)
          {
              return NotFound();
          }
            return await _context.Autoris.ToListAsync();
        }

        // GET: api/Autori/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Autori>> GetAutori(int id)
        {
          if (_context.Autoris == null)
          {
              return NotFound();
          }
            var autori = await _context.Autoris.FindAsync(id);

            if (autori == null)
            {
                return NotFound();
            }

            return autori;
        }

        // PUT: api/Autori/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutori(int id, Autori autori)
        {
            if (id != autori.Id)
            {
                return BadRequest();
            }

            _context.Entry(autori).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutoriExists(id))
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

        // POST: api/Autori
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Autori>> PostAutori(Autori autori)
        {
          if (_context.Autoris == null)
          {
              return Problem("Entity set 'BibliotecaDbContext.Autoris'  is null.");
          }
            _context.Autoris.Add(autori);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutori", new { id = autori.Id }, autori);
        }

        // DELETE: api/Autori/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutori(int id)
        {
            if (_context.Autoris == null)
            {
                return NotFound();
            }
            var autori = await _context.Autoris.FindAsync(id);
            if (autori == null)
            {
                return NotFound();
            }

            _context.Autoris.Remove(autori);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AutoriExists(int id)
        {
            return (_context.Autoris?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
