using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace web.econecta.dpa.core.Core.Entities;

[Index(nameof(IdDestinatario), nameof(LeidoEn), Name = "IX_Notif_Bandeja")]
public partial class Notificacione
{
    [Key]
    public long IdNotificacion { get; set; }

    public long IdDestinatario { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string Tipo { get; set; } = null!;

    [StringLength(120)]
    public string Titulo { get; set; } = null!;

    [StringLength(500)]
    public string? Cuerpo { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string Canal { get; set; } = null!;

    public long? IdProductoRelacionado { get; set; }

    public long? IdTransaccionRelacionada { get; set; }

    public DateTime? LeidoEn { get; set; }

    public DateTime CreadoEn { get; set; }

    public virtual Usuario? IdDestinatarioNavigation { get; set; }
    public virtual Producto? IdProductoRelacionadoNavigation { get; set; }
    public virtual Transaccione? IdTransaccionRelacionadaNavigation { get; set; }
}