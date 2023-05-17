using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AgendaMedica.Models;

public partial class BdagendaContext : DbContext
{
    public BdagendaContext()
    {
    }

    public BdagendaContext(DbContextOptions<BdagendaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agendar> Agendars { get; set; }

    public virtual DbSet<Atencion> Atencions { get; set; }

    public virtual DbSet<Especialidad> Especialidads { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Prevision> Previsions { get; set; }

    public virtual DbSet<Sector> Sectors { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    {
        if (!optionsBuilder.IsConfigured)
        {
            //optionsBuilder.UseSqlServer("server=PC31LAB108; initial catalog=InventarioDB; user id=sa;password=ipvg2023;");
            //optionsBuilder.UseSqlServer("server=.\\sqlexpress06; initial catalog=InventarioDB; Trusted_connection =True;");
            //optionsBuilder.UseSqlServer("server=DESKTOP-RVLJI2G\\SQLEXPRESS; initial catalog=InventarioDB; user id=sa;password=Ariquelme;");
            // Casa Alicia                   
            optionsBuilder.UseSqlServer("server=DESKTOP-RVLJI2G\\SQLEXPRESS; initial catalog=BDAgenda; user id=sa;password=Ariquelme; TrustServerCertificate=True;");//we

        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agendar>(entity =>
        {
            entity.HasKey(e => e.IdAg);

            entity.ToTable("Agendar");

            entity.Property(e => e.IdAg).HasColumnName("id_ag");
            entity.Property(e => e.ApePac)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("ape_pac");
            entity.Property(e => e.DirPac)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("dir_pac");
            entity.Property(e => e.FechaAg)
                .HasColumnType("date")
                .HasColumnName("fecha_ag");
            entity.Property(e => e.FonoPac)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("fono_pac");
            entity.Property(e => e.HoraAg).HasColumnName("hora_ag");
            entity.Property(e => e.IdAte).HasColumnName("id_ate");
            entity.Property(e => e.IdEsp).HasColumnName("id_esp");
            entity.Property(e => e.IdPrev).HasColumnName("id_prev");
            entity.Property(e => e.IdSector).HasColumnName("id_sector");
            entity.Property(e => e.NomPac)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nom_pac");
            entity.Property(e => e.RutPac)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("rut_pac");

            entity.HasOne(d => d.IdAteNavigation).WithMany(p => p.Agendars)
                .HasForeignKey(d => d.IdAte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Agendar_Atencion");

            entity.HasOne(d => d.IdEspNavigation).WithMany(p => p.Agendars)
                .HasForeignKey(d => d.IdEsp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Agendar_Especialidad");

            entity.HasOne(d => d.IdPrevNavigation).WithMany(p => p.Agendars)
                .HasForeignKey(d => d.IdPrev)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Agendar_Prevision");

            entity.HasOne(d => d.IdSectorNavigation).WithMany(p => p.Agendars)
                .HasForeignKey(d => d.IdSector)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Agendar_Sector");

            entity.HasOne(d => d.RutPacNavigation).WithMany(p => p.Agendars)
                .HasForeignKey(d => d.RutPac)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Agendar_Paciente1");
        });

        modelBuilder.Entity<Atencion>(entity =>
        {
            entity.HasKey(e => e.IdAte);

            entity.ToTable("Atencion");

            entity.Property(e => e.IdAte).HasColumnName("id_ate");
            entity.Property(e => e.NombreAte)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombre_ate");
        });

        modelBuilder.Entity<Especialidad>(entity =>
        {
            entity.HasKey(e => e.IdEsp);

            entity.ToTable("Especialidad");

            entity.Property(e => e.IdEsp).HasColumnName("id_esp");
            entity.Property(e => e.Especialidad1)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("especialidad");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.RutPac);

            entity.ToTable("Paciente");

            entity.Property(e => e.RutPac)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("rut_pac");
            entity.Property(e => e.ApellidosPac)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidos_pac");
            entity.Property(e => e.DireccionPac)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("direccion_pac");
            entity.Property(e => e.EdadPac).HasColumnName("edad_pac");
            entity.Property(e => e.EmailPac)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email_pac");
            entity.Property(e => e.FonoPac)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("fono_pac");
            entity.Property(e => e.NombrePac)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_pac");
        });

        modelBuilder.Entity<Prevision>(entity =>
        {
            entity.HasKey(e => e.IdPrev);

            entity.ToTable("Prevision");

            entity.Property(e => e.IdPrev).HasColumnName("id_prev");
            entity.Property(e => e.NombrePrev)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre_prev");
        });

        modelBuilder.Entity<Sector>(entity =>
        {
            entity.HasKey(e => e.IdSector);

            entity.ToTable("Sector");

            entity.Property(e => e.IdSector).HasColumnName("id_sector");
            entity.Property(e => e.Sector1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sector");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUs);

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUs).HasColumnName("id_us");
            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.NombreUs)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombre_us");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
