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
    public class IndexModel : PageModel
    {
        private readonly ClientiFattureRazorWeb.Models.CFContext _context;

        public IndexModel(ClientiFattureRazorWeb.Models.CFContext context)
        {
            _context = context;
        }

        public IList<Fattura> Fattura { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Fatture != null)
            {
                Fattura = await _context.Fatture
                .Include(f => f.Cliente).ToListAsync();
            }
        }
    }
}
