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

    [ForeignKey("IdUsuario")]
    [InverseProperty("EjecucionesReportes")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}

public class EjecucionesReporteRepository
{
    private readonly EcoConectaDBContext _context;
    public EjecucionesReporteRepository(EcoConectaDBContext context) => _context = context;

    public IQueryable<EjecucionesReporte> Query() => _context.Set<EjecucionesReporte>();
    public Task<List<EjecucionesReporte>> GetAllAsync() => Query().ToListAsync();
    public Task<EjecucionesReporte?> GetByIdAsync(long id) => Query().FirstOrDefaultAsync(e => e.IdEjecucion == id);
}
