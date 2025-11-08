using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace web.econecta.dpa.core.Core.Entities;

[Index(nameof(Nombre), Name = "UQ__Roles__75E3EFCFF3B2A34E", IsUnique = true)]
public partial class Role
{
    [Key]
    public int IdRol { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    public virtual ICollection<Usuario>? IdUsuarios { get; set; }
}