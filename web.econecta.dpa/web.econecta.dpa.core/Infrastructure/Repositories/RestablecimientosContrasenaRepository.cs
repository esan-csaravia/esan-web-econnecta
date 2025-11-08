using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Infrastructure.Data;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.core.Infrastructure.Repositories;

public class RestablecimientosContrasenaRepository : IRestablecimientosContrasenaRepository
{
    private readonly EcoConectaDBContext _context;
    public RestablecimientosContrasenaRepository(EcoConectaDBContext context) => _context = context;

    public IQueryable<RestablecimientosContrasena> Query() => _context.Set<RestablecimientosContrasena>();
    public Task<List<RestablecimientosContrasena>> GetAllAsync() => Query().ToListAsync();
    public Task<RestablecimientosContrasena?> GetByIdAsync(long id) => Query().FirstOrDefaultAsync(r => r.IdRestablecimiento == id);

    public async Task AddAsync(RestablecimientosContrasena entity) { _context.Set<RestablecimientosContrasena>().Add(entity); await _context.SaveChangesAsync(); }
    public async Task UpdateAsync(RestablecimientosContrasena entity) { _context.Set<RestablecimientosContrasena>().Update(entity); await _context.SaveChangesAsync(); }
    public async Task DeleteAsync(RestablecimientosContrasena entity) { _context.Set<RestablecimientosContrasena>().Remove(entity); await _context.SaveChangesAsync(); }
}
