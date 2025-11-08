using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace web.econecta.dpa.core.Core.Entities;

[Index(nameof(IdCategoria), nameof(IdDistrito), nameof(TipoPublicacion), nameof(EstadoModeracion), Name = "IX_Productos_Busqueda")]
[Index(nameof(Titulo), Name = "IX_Productos_Titulo")]
public partial class Producto
{
    [Key]
    public long IdProducto { get; set; }

    public long IdVendedor { get; set; }

    [StringLength(150)]
    public string Titulo { get; set; } = null!;

    [StringLength(1500)]
    public string Descripcion { get; set; } = null!;

    public int IdCategoria { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string TipoPublicacion { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string Condicion { get; set; } = null!;

    [Column(TypeName = "decimal(12, 2)")]
    public decimal? Precio { get; set; }

    public int Cantidad { get; set; }

    public int? IdDistrito { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string EstadoModeracion { get; set; } = null!;

    [StringLength(300)]
    public string? MotivoModeracion { get; set; }

    public long? IdModerador { get; set; }

    public DateTime? ModeradoEn { get; set; }

    public bool Activo { get; set; }

    public DateTime CreadoEn { get; set; }

    public DateTime? ActualizadoEn { get; set; }

    // Navigation properties
    public virtual ICollection<Comentario>? Comentarios { get; set; }
    public virtual Categoria? IdCategoriaNavigation { get; set; }
    public virtual Distrito? IdDistritoNavigation { get; set; }
    public virtual Usuario? IdModeradorNavigation { get; set; }
    public virtual Usuario? IdVendedorNavigation { get; set; }
    public virtual ICollection<ImagenesProducto>? ImagenesProductos { get; set; }
    public virtual ICollection<InteresesProducto>? InteresesProductos { get; set; }
    public virtual ICollection<Notificacione>? Notificaciones { get; set; }
    public virtual ICollection<Transaccione>? Transacciones { get; set; }
}