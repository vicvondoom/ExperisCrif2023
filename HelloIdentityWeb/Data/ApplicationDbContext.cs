using HelloIdentityWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HelloIdentityWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Materiale> Materiali { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}