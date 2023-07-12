using Microsoft.EntityFrameworkCore;

namespace NegozioCellulariWeb.Models
{
    public class NegozioCellulariContext : DbContext
    {
        public DbSet<Cellulare> Cellulari { get; set;}

        public NegozioCellulariContext(DbContextOptions<NegozioCellulariContext> options) : base(options)
        {
        
        }
    }
}
