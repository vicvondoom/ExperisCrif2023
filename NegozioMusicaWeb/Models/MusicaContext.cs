using Microsoft.EntityFrameworkCore;

namespace NegozioMusicaWeb.Models
{
    // 1) deve estendere da DbContext
    public class MusicaContext : DbContext
    {
        // 2) Fare i DbSet per ogni tabella da generare
        public DbSet<Prodotto> Prodotti { get; set; }

        // 3) Mi creo un costruttore di questo tipo
        public MusicaContext(DbContextOptions<MusicaContext> options) : base(options)
        {
        
        }
    }
}
