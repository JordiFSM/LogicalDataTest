using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LogicalData.Data.Context;

public partial class LogicalDataDbContext : DbContext
{
    public LogicalDataDbContext()
    {
    }

    public LogicalDataDbContext(DbContextOptions<LogicalDataDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Orden> Ordens { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DataBase");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PkItem");

            entity.ToTable("Item", "Ventas", tb => tb.HasComment("Almacena los items de las ordenes del sistema."));

            entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Orden).WithMany(p => p.Items)
                .HasForeignKey(d => d.OrdenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkItemOrdenId");

            entity.HasOne(d => d.Producto).WithMany(p => p.Items)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkItemProductoId");
        });

        modelBuilder.Entity<Orden>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PkOrdenId");

            entity.ToTable("Orden", "Ventas", tb => tb.HasComment("Almacena las ordenes del sistema"));

            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Ordens)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkOrdenUsuarioId");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PkProductoId");

            entity.ToTable("Producto", "Inventarios", tb => tb.HasComment("Almacena los productos del sistema."));

            entity.HasIndex(e => e.Codigo, "UqProductoCodigo").IsUnique();

            entity.Property(e => e.Codigo).HasMaxLength(25);
            entity.Property(e => e.Descripcion).HasMaxLength(100);
            entity.Property(e => e.Iva).HasColumnName("IVA");
            entity.Property(e => e.Nombre).HasMaxLength(25);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PkUsuarioId");

            entity.ToTable("Usuario", "Usuarios", tb => tb.HasComment("Almacena los usuarios del sistema."));

            entity.HasIndex(e => e.Nombre, "UqNombre").IsUnique();

            entity.Property(e => e.Apellido).HasMaxLength(25);
            entity.Property(e => e.Contrasenia).HasMaxLength(64);
            entity.Property(e => e.Nombre).HasMaxLength(25);
            entity.Property(e => e.Username).HasMaxLength(25);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
