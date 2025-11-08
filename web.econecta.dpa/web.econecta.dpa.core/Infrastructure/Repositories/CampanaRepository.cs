using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Infrastructure.Data;

namespace web.econecta.dpa.core.Infrastructure.Repositories;

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

    [ForeignKey("IdCreador")]
    [InverseProperty("Campanas")]
    public virtual Usuario IdCreadorNavigation { get; set; } = null!;
}

public class CampanaRepository
{
    private readonly EcoConectaDBContext _context;
    public CampanaRepository(EcoConectaDBContext context) => _context = context;

    public IQueryable<Campana> Query() => _context.Set<Campana>();
    public Task<List<Campana>> GetAllAsync() => Query().ToListAsync();
    public Task<Campana?> GetByIdAsync(long id) => Query().FirstOrDefaultAsync(c => c.IdCampana == id);
}
