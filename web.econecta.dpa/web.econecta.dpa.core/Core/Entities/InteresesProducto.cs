using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace web.econecta.dpa.core.Core.Entities;

[Table("InteresesProducto")]
[Index(nameof(IdProducto), nameof(IdComprador), Name = "UQ_Interes_Usuario_Producto", IsUnique = true)]
public partial class InteresesProducto
{
    [Key]
    public long IdInteres { get; set; }

    public long IdProducto { get; set; }

    public long IdComprador { get; set; }

    [StringLength(300)]
    public string? Mensaje { get; set; }

    public DateTime CreadoEn { get; set; }

    public virtual Usuario? IdCompradorNavigation { get; set; }
    public virtual Producto? IdProductoNavigation { get; set; }
}