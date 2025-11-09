using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace web.econecta.dpa.core.Core.Entities;

[Table("EjecucionesReporte")]
public partial class EjecucionesReporte
{
    [Key]
    public long IdEjecucion { get; set; }

    public long IdUsuario { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string TipoReporte { get; set; } = null!;

    public DateOnly? DesdeFecha { get; set; }

    public DateOnly? HastaFecha { get; set; }

    public DateTime EjecutadoEn { get; set; }

    public int? FilasAfectadas { get; set; }
}