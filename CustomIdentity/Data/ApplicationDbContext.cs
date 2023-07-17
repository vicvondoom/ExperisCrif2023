using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CustomIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext<CustomUser, IdentityRole, string>
    {
        public DbSet<Ordine> Ordini { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}