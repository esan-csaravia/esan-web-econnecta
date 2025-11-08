using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace web.econecta.dpa.core.Core.Entities;

[Index(nameof(Correo), IsUnique = true)]
public partial class Usuario
{
    [Key]
    public long IdUsuario { get; set; }

    [StringLength(120)]
    public string NombreCompleto { get; set; } = null!;

    [StringLength(120)]
    [Unicode(false)]
    public string Correo { get; set; } = null!;

    [MaxLength(200)]
    public byte[] HashContrasena { get; set; } = null!;

    public int? IdDistrito { get; set; }

    public bool CorreoConfirmado { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Estado { get; set; } = null!;

    [Column(TypeName = "decimal(4, 2)")]
    public decimal PuntajePromedio { get; set; }

    public int ConteoPuntajes { get; set; }

    public DateTime CreadoEn { get; set; }

    public DateTime? UltimoIngresoEn { get; set; }

    // Navigation properties
    public virtual ICollection<AccionesAdministrativasUsuario>? AccionesAdministrativasUsuarioIdUsuarioAdminNavigations { get; set; }
    public virtual ICollection<AccionesAdministrativasUsuario>? AccionesAdministrativasUsuarioIdUsuarioObjetivoNavigations { get; set; }
    public virtual ICollection<Calificacione>? CalificacioneIdCalificadoNavigations { get; set; }
    public virtual ICollection<Calificacione>? CalificacioneIdCalificadorNavigations { get; set; }
    public virtual ICollection<Campana>? Campanas { get; set; }
    public virtual ICollection<Comentario>? Comentarios { get; set; }
    public virtual ICollection<EjecucionesReporte>? EjecucionesReportes { get; set; }
    public virtual Distrito? IdDistritoNavigation { get; set; }
    public virtual ICollection<InteresesProducto>? InteresesProductos { get; set; }
    public virtual ICollection<Notificacione>? Notificaciones { get; set; }
    public virtual ICollection<Producto>? ProductoIdModeradorNavigations { get; set; }
    public virtual ICollection<Producto>? ProductoIdVendedorNavigations { get; set; }
    public virtual ICollection<RestablecimientosContrasena>? RestablecimientosContrasenas { get; set; }
    public virtual ICollection<Transaccione>? TransaccioneIdCompradorNavigations { get; set; }
    public virtual ICollection<Transaccione>? TransaccioneIdVendedorNavigations { get; set; }
    public virtual ICollection<VerificacionesCorreo>? VerificacionesCorreos { get; set; }
    public virtual ICollection<Role>? IdRols { get; set; }
}