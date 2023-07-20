using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BiblioBlazorServer.Models;

public partial class BibliotecaDbContext : DbContext
{
    public BibliotecaDbContext()
    {
    }

    public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autori> Autoris { get; set; }

    public virtual DbSet<Editori> Editoris { get; set; }

    public virtual DbSet<Libri> Libris { get; set; }

    public virtual DbSet<TbLog> TbLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-G8CEV4R;Database=BibliotecaDB;Trusted_Connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autori>(entity =>
        {
            entity.ToTable("Autori");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cognome).HasMaxLength(50);
            entity.Property(e => e.Nome).HasMaxLength(50);
        });

        modelBuilder.Entity<Editori>(entity =>
        {
            entity.ToTable("Editori");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descrizione).HasMaxLength(50);
            entity.Property(e => e.Sede).HasMaxLength(50);
        });

        modelBuilder.Entity<Libri>(entity =>
        {
            entity.ToTable("Libri");

            entity.HasIndex(e => e.IdAutore, "IX_Libri_IdAutore");

            entity.HasIndex(e => e.IdEditore, "IX_Libri_IdEditore");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Titolo).HasMaxLength(150);

            entity.HasOne(d => d.IdAutoreNavigation).WithMany(p => p.Libris).HasForeignKey(d => d.IdAutore);

            entity.HasOne(d => d.IdEditoreNavigation).WithMany(p => p.Libris).HasForeignKey(d => d.IdEditore);
        });

        modelBuilder.Entity<TbLog>(entity =>
        {
            entity.ToTable("tbLogs");

            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
