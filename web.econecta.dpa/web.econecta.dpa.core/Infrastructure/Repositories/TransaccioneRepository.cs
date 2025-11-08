using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Infrastructure.Data;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.core.Infrastructure.Repositories;

public class TransaccioneRepository : ITransaccioneRepository
{
    private readonly EcoConectaDBContext _context;
    public TransaccioneRepository(EcoConectaDBContext context) => _context = context;

    public IQueryable<Transaccione> Query() => _context.Set<Transaccione>();
    public Task<List<Transaccione>> GetAllAsync() => Query().ToListAsync();
    public Task<Transaccione?> GetByIdAsync(long id) => Query().FirstOrDefaultAsync(t => t.IdTransaccion == id);

    public async Task AddAsync(Transaccione entity) { _context.Set<Transaccione>().Add(entity); await _context.SaveChangesAsync(); }
    public async Task UpdateAsync(Transaccione entity) { _context.Set<Transaccione>().Update(entity); await _context.SaveChangesAsync(); }
    public async Task DeleteAsync(Transaccione entity) { _context.Set<Transaccione>().Remove(entity); await _context.SaveChangesAsync(); }
}
