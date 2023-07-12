﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProvaPowerTools.Models
{
    public partial class AziendaContext : DbContext
    {
        public AziendaContext()
        {
        }

        public AziendaContext(DbContextOptions<AziendaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aliquote> Aliquote { get; set; }
        public virtual DbSet<Fatture> Fatture { get; set; }
        public virtual DbSet<tbUtenti> tbUtenti { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fatture>(entity =>
            {
                entity.Property(e => e.IdAliquota).HasDefaultValueSql("((3))");

                entity.HasOne(d => d.IdAliquotaNavigation)
                    .WithMany(p => p.Fatture)
                    .HasForeignKey(d => d.IdAliquota)
                    .HasConstraintName("FK_Fatture_Aliquote");
            });

            modelBuilder.Entity<tbUtenti>(entity =>
            {
                entity.Property(e => e.Gender).IsFixedLength();
            });

            OnModelCreatingGeneratedProcedures(modelBuilder);
            OnModelCreatingGeneratedFunctions(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}