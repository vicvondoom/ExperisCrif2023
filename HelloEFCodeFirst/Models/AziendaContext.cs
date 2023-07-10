using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloEFCodeFirst.Models
{
    // 1) deve ereditare da DbContext
    internal class AziendaContext : DbContext
    {
        // 2) Devo scrivere un DbSet<T> per ogni classe che diventerà una tabella
        public DbSet<Prodotto> Prodotti { get; set; }
        public DbSet<Categoria> Categorie { get; set; }


        // 3) In un progetto web ci vorrebbe un costruttore apposito,
        // ma per ora noi usiamo l'override di un metodo
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DAVIDEORLAN17BB;Database=HelloEFCodeFirst;Trusted_Connection=True;TrustServerCertificate=true;");
        }
    }
}
