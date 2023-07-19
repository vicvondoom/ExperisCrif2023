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
    public class EditoriController : ControllerBase
    {
        private readonly BibliotecaDbContext _context;

        public EditoriController(BibliotecaDbContext context)
        {
            _context = context;
        }

        // GET: api/Editori
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editori>>> GetEditoris()
        {
          if (_context.Editoris == null)
          {
              return NotFound();
          }
            return await _context.Editoris.ToListAsync();
        }

        // GET: api/Editori/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Editori>> GetEditori(int id)
        {
          if (_context.Editoris == null)
          {
              return NotFound();
          }
            var editori = await _context.Editoris.FindAsync(id);

            if (editori == null)
            {
                return NotFound();
            }

            return editori;
        }

        // PUT: api/Editori/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEditori(int id, Editori editori)
        {
            if (id != editori.Id)
            {
                return BadRequest();
            }

            _context.Entry(editori).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EditoriExists(id))
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

        // POST: api/Editori
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Editori>> PostEditori(Editori editori)
        {
          if (_context.Editoris == null)
          {
              return Problem("Entity set 'BibliotecaDbContext.Editoris'  is null.");
          }
            _context.Editoris.Add(editori);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEditori", new { id = editori.Id }, editori);
        }

        // DELETE: api/Editori/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEditori(int id)
        {
            if (_context.Editoris == null)
            {
                return NotFound();
            }
            var editori = await _context.Editoris.FindAsync(id);
            if (editori == null)
            {
                return NotFound();
            }

            _context.Editoris.Remove(editori);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EditoriExists(int id)
        {
            return (_context.Editoris?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
