using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HelloEFDBFirst.Models;

public partial class HelloEfdbfirstContext : DbContext
{
    public HelloEfdbfirstContext()
    {
    }

    public HelloEfdbfirstContext(DbContextOptions<HelloEfdbfirstContext> options)
        : base(options)
    {
    }

    // Questa riga rappresenta la collezione di Persone (=la tabella del database)
    public virtual DbSet<Persone> Persones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DAVIDEORLAN17BB;Database=HelloEFDBFirst;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Persone>(entity =>
        {
            entity.ToTable("Persone");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cognome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
