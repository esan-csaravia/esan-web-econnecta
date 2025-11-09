using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace web.econecta.dpa.core.Core.Entities;

[Index(nameof(Nombre), Name = "UQ__Distrito__75E3EFCF3D1E0705", IsUnique = true)]
public partial class Distrito
{
    [Key]
    public int IdDistrito { get; set; }

    [StringLength(80)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;
}