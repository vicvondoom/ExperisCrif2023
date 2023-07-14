using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClientiFattureRazorWeb.Models;

namespace ClientiFattureRazorWeb.Pages.Clienti
{
    public class DetailsModel : PageModel
    {
        private readonly ClientiFattureRazorWeb.Models.CFContext _context;

        public DetailsModel(ClientiFattureRazorWeb.Models.CFContext context)
        {
            _context = context;
        }

      public Cliente Cliente { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Clienti == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clienti.FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            else 
            {
                Cliente = cliente;
            }
            return Page();
        }
    }
}
