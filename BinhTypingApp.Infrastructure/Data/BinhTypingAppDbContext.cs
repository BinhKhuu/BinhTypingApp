using System;
using System.Collections.Generic;
using BinhTypingApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BinhTypingApp.Infrastructure.Data;

public partial class BinhTypingAppDbContext : DbContext
{
    public BinhTypingAppDbContext()
    {
    }

    public BinhTypingAppDbContext(DbContextOptions<BinhTypingAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Quote> Quotes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    if(!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BinhTypingApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    }
       

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Language__3214EC078BE27FC4");

            entity.HasIndex(e => e.Language1, "UQ__Language__C3D59250D6D553CF").IsUnique();

            entity.Property(e => e.Language1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Language");
        });

        modelBuilder.Entity<Quote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Quotes__3214EC073A32BAB2");

            entity.Property(e => e.QuoteLanguage)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.QuoteSize)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.QuoteSource)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.QuoteValue).IsUnicode(false);

            entity.HasOne(d => d.QuoteLanguageNavigation).WithMany(p => p.Quotes)
                .HasPrincipalKey(p => p.Language1)
                .HasForeignKey(d => d.QuoteLanguage)
                .HasConstraintName("FK__Quotes__QuoteLan__276EDEB3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
