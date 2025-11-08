using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Infrastructure.Data;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.core.Infrastructure.Repositories;

public class DistritoRepository : IDistritoRepository
{
    private readonly EcoConectaDBContext _context;
    public DistritoRepository(EcoConectaDBContext context) => _context = context;

    public IQueryable<Distrito> Query() => _context.Set<Distrito>();
    public Task<List<Distrito>> GetAllAsync() => Query().ToListAsync();
    public Task<Distrito?> GetByIdAsync(long id) => Query().FirstOrDefaultAsync(d => d.IdDistrito == id);

    public async Task AddAsync(Distrito entity) { _context.Set<Distrito>().Add(entity); await _context.SaveChangesAsync(); }
    public async Task UpdateAsync(Distrito entity) { _context.Set<Distrito>().Update(entity); await _context.SaveChangesAsync(); }
    public async Task DeleteAsync(Distrito entity) { _context.Set<Distrito>().Remove(entity); await _context.SaveChangesAsync(); }
}
