using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.econecta.dpa.core.Core.Entities;

public partial class Comentario
{
    [Key]
    public long IdComentario { get; set; }

    public long IdProducto { get; set; }

    public long IdAutor { get; set; }

    [StringLength(200)]
    public string Cuerpo { get; set; } = null!;

    public DateTime CreadoEn { get; set; }

    public DateTime? ActualizadoEn { get; set; }

    public bool Eliminado { get; set; }
}