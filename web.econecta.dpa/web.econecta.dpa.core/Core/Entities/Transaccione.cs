using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace web.econecta.dpa.core.Core.Entities;

[Index(nameof(IdComprador), nameof(IdVendedor), nameof(CreadoEn), Name = "IX_Trx_Usuarios_Tiempo", IsDescending = new[] { false, false, true })]
public partial class Transaccione
{
    [Key]
    public long IdTransaccion { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string Tipo { get; set; } = null!;

    public long IdProducto { get; set; }

    public long IdVendedor { get; set; }

    public long IdComprador { get; set; }

    public int Cantidad { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal? PrecioUnitario { get; set; }

    [Column(TypeName = "decimal(23, 2)")]
    public decimal? MontoTotal { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string Estado { get; set; } = null!;

    public DateTime CreadoEn { get; set; }

    public DateTime? CompletadoEn { get; set; }

    public virtual Calificacione? Calificacione { get; set; }
    public virtual Usuario? IdCompradorNavigation { get; set; }
    public virtual Producto? IdProductoNavigation { get; set; }
    public virtual Usuario? IdVendedorNavigation { get; set; }
    public virtual ICollection<Notificacione>? Notificaciones { get; set; }
}