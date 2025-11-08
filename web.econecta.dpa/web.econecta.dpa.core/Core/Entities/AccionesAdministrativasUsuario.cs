using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace web.econecta.dpa.core.Core.Entities;

[Table("AccionesAdministrativasUsuario")]
public partial class AccionesAdministrativasUsuario
{
    [Key]
    public long IdAccion { get; set; }

    public long IdUsuarioObjetivo { get; set; }

    public long IdUsuarioAdmin { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Accion { get; set; } = null!;

    [StringLength(300)]
    public string? Motivo { get; set; }

    public DateTime CreadoEn { get; set; }

    public DateTime? TerminaEn { get; set; }

    public virtual Usuario? IdUsuarioAdminNavigation { get; set; }
    public virtual Usuario? IdUsuarioObjetivoNavigation { get; set; }
}