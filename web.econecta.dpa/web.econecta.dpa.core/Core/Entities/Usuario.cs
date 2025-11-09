using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace web.econecta.dpa.core.Core.Entities;

[Index(nameof(Correo), IsUnique = true)]
public partial class Usuario
{
    [Key]
    public long IdUsuario { get; set; }

    [StringLength(120)]
    public string NombreCompleto { get; set; } = null!;

    [StringLength(120)]
    [Unicode(false)]
    public string Correo { get; set; } = null!;

    [MaxLength(200)]
    public byte[] HashContrasena { get; set; } = null!;

    public int? IdDistrito { get; set; }

    public bool CorreoConfirmado { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Estado { get; set; } = null!;

    [Column(TypeName = "decimal(4, 2)")]
    public decimal PuntajePromedio { get; set; }

    public int ConteoPuntajes { get; set; }

    public DateTime CreadoEn { get; set; }

    public DateTime? UltimoIngresoEn { get; set; }
}