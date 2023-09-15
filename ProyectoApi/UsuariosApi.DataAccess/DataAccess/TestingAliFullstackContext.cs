using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Usuarios.DataAccess.DataAccess;

public partial class TestingAliFullstackContext : DbContext
{
    public TestingAliFullstackContext()
    {
    }

    public TestingAliFullstackContext(DbContextOptions<TestingAliFullstackContext> options)
        : base(options)
    {
    }    

    public virtual DbSet<UsersTestMiguelEmanuelSanchezRamo> UsersTestMiguelEmanuelSanchezRamos { get; set; }

    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=data-avimo.cgriqmyweq5c.us-east-2.rds.amazonaws.com;database=testing_ali_fullstack;uid=testing;pwd=Pruebas%ALI%2020", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.38-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");
        

        modelBuilder.Entity<UsersTestMiguelEmanuelSanchezRamo>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.ToTable("users_test_miguel_emanuel_sanchez_ramos");

            entity.Property(e => e.IdUsuario).HasColumnType("int(11)");
            entity.Property(e => e.ApellidoMaterno).HasMaxLength(250);
            entity.Property(e => e.ApellidoPaterno).HasMaxLength(250);
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(250);
            entity.Property(e => e.SegundoNombre).HasMaxLength(250);
            entity.Property(e => e.Telefono).HasMaxLength(250);
        });        

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
