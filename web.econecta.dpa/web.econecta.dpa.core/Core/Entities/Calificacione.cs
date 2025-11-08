using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace web.econecta.dpa.core.Core.Entities;

//[Index(nameof(IdTransaccion), Name = "UQ__Califica__334B1F76B40EE4A3", IsUnique = true)]
public partial class Calificacione
{
    [Key]
    public long IdCalificacion { get; set; }

    public long IdTransaccion { get; set; }

    public long IdCalificador { get; set; }

    public long IdCalificado { get; set; }

    public byte Estrellas { get; set; }

    [StringLength(300)]
    public string? Comentario { get; set; }

    public DateTime CreadoEn { get; set; }

    public virtual Usuario? IdCalificadoNavigation { get; set; }
    public virtual Usuario? IdCalificadorNavigation { get; set; }
    public virtual Transaccione? IdTransaccionNavigation { get; set; }
}