using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClientiFattureRazorWeb.Models;

namespace ClientiFattureRazorWeb.Pages.Fatture
{
    public class DeleteModel : PageModel
    {
        private readonly ClientiFattureRazorWeb.Models.CFContext _context;

        public DeleteModel(ClientiFattureRazorWeb.Models.CFContext context)
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

            var fattura = await _context.Fatture.FirstOrDefaultAsync(m => m.Id == id);

            if (fattura == null)
            {
                return NotFound();
            }
            else 
            {
                Fattura = fattura;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Fatture == null)
            {
                return NotFound();
            }
            var fattura = await _context.Fatture.FindAsync(id);

            if (fattura != null)
            {
                Fattura = fattura;
                _context.Fatture.Remove(Fattura);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
