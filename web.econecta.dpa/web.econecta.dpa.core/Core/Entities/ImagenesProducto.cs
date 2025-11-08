using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace web.econecta.dpa.core.Core.Entities;

[Table("ImagenesProducto")]
[Index(nameof(IdProducto), nameof(Orden), Name = "UX_ImagenesProducto_Limite", IsUnique = true)]
public partial class ImagenesProducto
{
    [Key]
    public long IdImagen { get; set; }

    public long IdProducto { get; set; }

    [StringLength(400)]
    public string RutaAlmacenamiento { get; set; } = null!;

    public byte Orden { get; set; }

    public DateTime CreadoEn { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}