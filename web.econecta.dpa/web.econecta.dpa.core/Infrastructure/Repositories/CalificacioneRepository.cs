using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Infrastructure.Data;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.core.Infrastructure.Repositories;

public class CalificacioneRepository : ICalificacioneRepository
{
    private readonly EcoConectaDBContext _context;
    public CalificacioneRepository(EcoConectaDBContext context) => _context = context;

    public IQueryable<Calificacione> Query() => _context.Set<Calificacione>();
    public Task<List<Calificacione>> GetAllAsync() => Query().ToListAsync();
    public Task<Calificacione?> GetByIdAsync(long id) => Query().FirstOrDefaultAsync(c => c.IdCalificacion == id);

    public async Task AddAsync(Calificacione entity) { _context.Set<Calificacione>().Add(entity); await _context.SaveChangesAsync(); }
    public async Task UpdateAsync(Calificacione entity) { _context.Set<Calificacione>().Update(entity); await _context.SaveChangesAsync(); }
    public async Task DeleteAsync(Calificacione entity) { _context.Set<Calificacione>().Remove(entity); await _context.SaveChangesAsync(); }
}
