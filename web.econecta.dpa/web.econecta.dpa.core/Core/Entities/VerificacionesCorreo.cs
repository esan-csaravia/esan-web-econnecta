using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace web.econecta.dpa.core.Core.Entities;

[Table("VerificacionesCorreo")]
[Index(nameof(Token), Name = "UQ__Verifica__1EB4F817014965DE", IsUnique = true)]
public partial class VerificacionesCorreo
{
    [Key]
    public long IdVerificacion { get; set; }

    public long IdUsuario { get; set; }

    [StringLength(64)]
    [Unicode(false)]
    public string Token { get; set; } = null!;

    public DateTime EnviadoEn { get; set; }

    public DateTime? ConfirmadoEn { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}