using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClientiFattureRazorWeb.Models;

namespace ClientiFattureRazorWeb.Pages.Fatture
{
    public class EditModel : PageModel
    {
        private readonly ClientiFattureRazorWeb.Models.CFContext _context;

        public EditModel(ClientiFattureRazorWeb.Models.CFContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Fattura Fattura { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Fatture == null)
            {
                return NotFound();
            }

            var fattura =  await _context.Fatture.FirstOrDefaultAsync(m => m.Id == id);
            if (fattura == null)
            {
                return NotFound();
            }
            Fattura = fattura;
           ViewData["IdCliente"] = new SelectList(_context.Clienti, "Id", "Nome");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Fattura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FatturaExists(Fattura.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FatturaExists(int id)
        {
          return (_context.Fatture?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
