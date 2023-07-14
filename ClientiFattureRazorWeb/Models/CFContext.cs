using Microsoft.EntityFrameworkCore;

namespace ClientiFattureRazorWeb.Models
{
    public class CFContext : DbContext
    {
        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Fattura> Fatture { get; set; }

        public CFContext(DbContextOptions<CFContext> options) : base(options) { }
    }
}
