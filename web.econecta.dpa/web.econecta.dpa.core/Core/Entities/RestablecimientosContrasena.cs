using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace web.econecta.dpa.core.Core.Entities;

[Table("RestablecimientosContrasena")]
[Index(nameof(Token), Name = "UQ__Restable__1EB4F817FF6BCBDA", IsUnique = true)]
public partial class RestablecimientosContrasena
{
    [Key]
    public long IdRestablecimiento { get; set; }

    public long IdUsuario { get; set; }

    [StringLength(64)]
    [Unicode(false)]
    public string Token { get; set; } = null!;

    public DateTime ExpiraEn { get; set; }

    public DateTime? UsadoEn { get; set; }

    public DateTime CreadoEn { get; set; }
}