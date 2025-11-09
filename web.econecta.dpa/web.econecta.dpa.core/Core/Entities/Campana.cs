using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace web.econecta.dpa.core.Core.Entities;

public partial class Campana
{
    [Key]
    public long IdCampana { get; set; }

    [StringLength(150)]
    public string Titulo { get; set; } = null!;

    [StringLength(1500)]
    public string Descripcion { get; set; } = null!;

    [StringLength(400)]
    public string? RutaImagen { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public bool Activa { get; set; }

    public long IdCreador { get; set; }

    public DateTime CreadoEn { get; set; }

    public DateTime? ActualizadoEn { get; set; }
}