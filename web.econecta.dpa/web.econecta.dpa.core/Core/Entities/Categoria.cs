using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace web.econecta.dpa.core.Core.Entities;

[Index(nameof(Nombre), Name = "UQ__Categori__75E3EFCF4A04EDBC", IsUnique = true)]
public partial class Categoria
{
    [Key]
    public int IdCategoria { get; set; }

    [StringLength(80)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    public int? IdPadre { get; set; }

    public virtual Categoria? IdPadreNavigation { get; set; }
    public virtual ICollection<Categoria>? InverseIdPadreNavigation { get; set; }
    public virtual ICollection<Producto>? Productos { get; set; }
}