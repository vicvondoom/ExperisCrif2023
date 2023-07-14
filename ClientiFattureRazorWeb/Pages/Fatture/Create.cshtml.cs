using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClientiFattureRazorWeb.Models;

namespace ClientiFattureRazorWeb.Pages.Fatture
{
    public class CreateModel : PageModel
    {
        private readonly ClientiFattureRazorWeb.Models.CFContext _context;

        public CreateModel(ClientiFattureRazorWeb.Models.CFContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["IdCliente"] = new SelectList(_context.Clienti, "Id", "Nome");
            return Page();
        }

        [BindProperty]
        public Fattura Fattura { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Fatture == null || Fattura == null)
            {
                return Page();
            }

            _context.Fatture.Add(Fattura);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
