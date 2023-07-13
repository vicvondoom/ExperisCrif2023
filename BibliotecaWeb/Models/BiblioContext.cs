using Microsoft.EntityFrameworkCore;

namespace BibliotecaWeb.Models
{
    public class BiblioContext : DbContext
    {
        public DbSet<Autore> Autori { get; set; }
        public DbSet<Editore> Editori { get; set; }
        public DbSet<Libro> Libri { get; set; }

        public BiblioContext(DbContextOptions<BiblioContext> options) : base(options) { }
    }
}
