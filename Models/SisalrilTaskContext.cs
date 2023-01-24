using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SisalrilProject.Models;

public partial class SisalrilTaskContext : DbContext
{
    public SisalrilTaskContext()
    {
    }

    public SisalrilTaskContext(DbContextOptions<SisalrilTaskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asignacione> Asignaciones { get; set; }

    public virtual DbSet<Edificio> Edificios { get; set; }

    public virtual DbSet<Trabajadore> Trabajadores { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS;Database=Sisalril_Task;Trusted_Connection=true;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asignacione>(entity =>
        {
            entity.HasKey(e => e.IdAsignacion);

            entity.Property(e => e.IdAsignacion).ValueGeneratedNever();
            entity.Property(e => e.AsignacionFechaInicio).HasColumnType("date");

            entity.HasOne(d => d.IdEdificioNavigation).WithMany(p => p.Asignaciones)
                .HasForeignKey(d => d.IdEdificio)
                .HasConstraintName("FK_Asignaciones_Edificios");

            entity.HasOne(d => d.IdTrabajadorNavigation).WithMany(p => p.Asignaciones)
                .HasForeignKey(d => d.IdTrabajador)
                .HasConstraintName("FK_Asignaciones_Trabajadores");
        });

        modelBuilder.Entity<Edificio>(entity =>
        {
            entity.HasKey(e => e.IdEdificio);

            entity.Property(e => e.IdEdificio).ValueGeneratedNever();
            entity.Property(e => e.EdificioDireccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoEdificio)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Trabajadore>(entity =>
        {
            entity.HasKey(e => e.IdTrabajador);

            entity.Property(e => e.IdTrabajador).ValueGeneratedNever();
            entity.Property(e => e.Oficio)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TrabajadorNombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TrabajadorTarifa).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
