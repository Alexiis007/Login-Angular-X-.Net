using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Login.Server.Models;

public partial class DBCUsuarios : DbContext
{
    public DBCUsuarios()
    {
    }

    public DBCUsuarios(DbContextOptions<DBCUsuarios> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    //EN LUGAR DE ESTO USEMOS MEJOR EL APPSETTINGS Y LA CONFIGURACION EN EL PROGRAM
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=Pruebas2022;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC0723622D07");

            entity.HasIndex(e => e.Correo, "UQ__Usuarios__60695A198D288A11").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.ContraseñaHash).HasMaxLength(256);
            entity.Property(e => e.Correo).HasMaxLength(150);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .HasDefaultValue("usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
