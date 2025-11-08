using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using web.econecta.dpa.core.Core.Entities;

namespace web.econecta.dpa.core.Infrastructure.Data;

public partial class EcoConectaDBContext : DbContext
{
    public EcoConectaDBContext(DbContextOptions<EcoConectaDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccionesAdministrativasUsuario> AccionesAdministrativasUsuarios { get; set; }

    public virtual DbSet<Calificacione> Calificaciones { get; set; }

    public virtual DbSet<Campana> Campanas { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Distrito> Distritos { get; set; }

    public virtual DbSet<EjecucionesReporte> EjecucionesReportes { get; set; }

    public virtual DbSet<ImagenesProducto> ImagenesProductos { get; set; }

    public virtual DbSet<InteresesProducto> InteresesProductos { get; set; }

    public virtual DbSet<Notificacione> Notificaciones { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<RestablecimientosContrasena> RestablecimientosContrasenas { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Transaccione> Transacciones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<VerificacionesCorreo> VerificacionesCorreos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccionesAdministrativasUsuario>(entity =>
        {
            entity.HasKey(e => e.IdAccion).HasName("PK__Acciones__9845169B8A41C63F");

            entity.Property(e => e.CreadoEn).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.IdUsuarioAdminNavigation).WithMany(p => p.AccionesAdministrativasUsuarioIdUsuarioAdminNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AAU_Admin");

            entity.HasOne(d => d.IdUsuarioObjetivoNavigation).WithMany(p => p.AccionesAdministrativasUsuarioIdUsuarioObjetivoNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AAU_Objetivo");
        });

        modelBuilder.Entity<Calificacione>(entity =>
        {
            entity.HasKey(e => e.IdCalificacion).HasName("PK__Califica__40E4A751811C782A");

            entity.Property(e => e.CreadoEn).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.IdCalificadoNavigation).WithMany(p => p.CalificacioneIdCalificadoNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calif_Calificado");

            entity.HasOne(d => d.IdCalificadorNavigation).WithMany(p => p.CalificacioneIdCalificadorNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calif_Calificador");

            entity.HasOne(d => d.IdTransaccionNavigation).WithOne(p => p.Calificacione)
                .HasForeignKey<Calificacione>(c => c.IdTransaccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calif_Trx");
        });

        modelBuilder.Entity<Campana>(entity =>
        {
            entity.HasKey(e => e.IdCampana).HasName("PK__Campanas__16A95A96E8D513C3");

            entity.Property(e => e.Activa).HasDefaultValue(true);
            entity.Property(e => e.CreadoEn).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.IdCreadorNavigation).WithMany(p => p.Campanas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Campanas_Admin");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A3C02A1093779572");

            entity.HasOne(d => d.IdPadreNavigation).WithMany(p => p.InverseIdPadreNavigation).HasConstraintName("FK_Categorias_Padre");
        });

        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.IdComentario).HasName("PK__Comentar__DDBEFBF9B624A848");

            entity.Property(e => e.CreadoEn).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.IdAutorNavigation).WithMany(p => p.Comentarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentarios_Autor");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Comentarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentarios_Producto");
        });

        modelBuilder.Entity<Distrito>(entity =>
        {
            entity.HasKey(e => e.IdDistrito).HasName("PK__Distrito__DE8EED594AA4832D");
        });

        modelBuilder.Entity<EjecucionesReporte>(entity =>
        {
            entity.HasKey(e => e.IdEjecucion).HasName("PK__Ejecucio__C0B117618AF5A160");

            entity.Property(e => e.EjecutadoEn).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.EjecucionesReportes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EjecucionesReporte_Usuario");
        });

        modelBuilder.Entity<ImagenesProducto>(entity =>
        {
            entity.HasKey(e => e.IdImagen).HasName("PK__Imagenes__B42D8F2AC0348A96");

            entity.Property(e => e.CreadoEn).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Orden).HasDefaultValue((byte)1);

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ImagenesProductos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ImagenesProducto_Producto");
        });

        modelBuilder.Entity<InteresesProducto>(entity =>
        {
            entity.HasKey(e => e.IdInteres).HasName("PK__Interese__9B417547770CDF67");

            entity.Property(e => e.CreadoEn).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.IdCompradorNavigation).WithMany(p => p.InteresesProductos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Interes_Comprador");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.InteresesProductos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Interes_Producto");
        });

        modelBuilder.Entity<Notificacione>(entity =>
        {
            entity.HasKey(e => e.IdNotificacion).HasName("PK__Notifica__F6CA0A85390676DE");

            entity.Property(e => e.Canal).HasDefaultValue("in_app");
            entity.Property(e => e.CreadoEn).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.IdDestinatarioNavigation).WithMany(p => p.Notificaciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notif_Destinatario");

            entity.HasOne(d => d.IdProductoRelacionadoNavigation).WithMany(p => p.Notificaciones).HasConstraintName("FK_Notif_Producto");

            entity.HasOne(d => d.IdTransaccionRelacionadaNavigation).WithMany(p => p.Notificaciones).HasConstraintName("FK_Notif_Trx");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__09889210C3CBC5C5");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Cantidad).HasDefaultValue(1);
            entity.Property(e => e.Condicion).HasDefaultValue("reciclado");
            entity.Property(e => e.CreadoEn).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.EstadoModeracion).HasDefaultValue("pendiente");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Productos_Categoria");

            entity.HasOne(d => d.IdDistritoNavigation).WithMany(p => p.Productos).HasConstraintName("FK_Productos_Distrito");

            entity.HasOne(d => d.IdModeradorNavigation).WithMany(p => p.ProductoIdModeradorNavigations).HasConstraintName("FK_Productos_Moderador");

            entity.HasOne(d => d.IdVendedorNavigation).WithMany(p => p.ProductoIdVendedorNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Productos_Vendedor");
        });

        modelBuilder.Entity<RestablecimientosContrasena>(entity =>
        {
            entity.HasKey(e => e.IdRestablecimiento).HasName("PK__Restable__89D30526B4D447B9");

            entity.Property(e => e.CreadoEn).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Token).IsFixedLength();

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.RestablecimientosContrasenas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Restablecer_Usuario");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Roles__2A49584C1C6FDAFE");
        });

        modelBuilder.Entity<Transaccione>(entity =>
        {
            entity.HasKey(e => e.IdTransaccion).HasName("PK__Transacc__334B1F77B12670B6");

            entity.Property(e => e.Cantidad).HasDefaultValue(1);
            entity.Property(e => e.CreadoEn).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Estado).HasDefaultValue("iniciada");
            entity.Property(e => e.MontoTotal).HasComputedColumnSql("([Cantidad]*isnull([PrecioUnitario],(0.00)))", true);

            entity.HasOne(d => d.IdCompradorNavigation).WithMany(p => p.TransaccioneIdCompradorNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trx_Comprador");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Transacciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trx_Producto");

            entity.HasOne(d => d.IdVendedorNavigation).WithMany(p => p.TransaccioneIdVendedorNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trx_Vendedor");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__5B65BF9789FE01A0");

            entity.Property(e => e.CreadoEn).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Estado).HasDefaultValue("activo");

            entity.HasOne(d => d.IdDistritoNavigation).WithMany(p => p.Usuarios).HasConstraintName("FK_Usuarios_Distritos");

            entity.HasMany(d => d.IdRols).WithMany(p => p.IdUsuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuariosRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UsuariosRoles_Rol"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UsuariosRoles_Usuario"),
                    j =>
                    {
                        j.HasKey("IdUsuario", "IdRol").HasName("PK__Usuarios__89C12A13048E157B");
                        j.ToTable("UsuariosRoles");
                    });
        });

        modelBuilder.Entity<VerificacionesCorreo>(entity =>
        {
            entity.HasKey(e => e.IdVerificacion).HasName("PK__Verifica__FB6090343E050A64");

            entity.Property(e => e.EnviadoEn).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Token).IsFixedLength();

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.VerificacionesCorreos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VerifCorreo_Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
