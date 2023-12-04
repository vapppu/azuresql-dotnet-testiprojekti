using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webapi.Models;

public partial class VeeratestidbContext : DbContext
{
    public VeeratestidbContext()
    {
    }

    public VeeratestidbContext(DbContextOptions<VeeratestidbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Koirat> Koirats { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:veeran-testiserveri.database.windows.net,1433;Initial Catalog=veeratestidb;Persist Security Info=False;User ID=veera;Password=KissaKissa123?;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Koirat>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Koirat");

            entity.Property(e => e.Ika).HasColumnName("ika");
            entity.Property(e => e.Nimi)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nimi");
            entity.Property(e => e.Rotu)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("rotu");
            entity.Property(e => e.Vari)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("vari");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
