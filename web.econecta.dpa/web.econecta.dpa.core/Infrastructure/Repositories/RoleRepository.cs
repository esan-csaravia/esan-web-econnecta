using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Infrastructure.Data;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.core.Infrastructure.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly EcoConectaDBContext _context;
    public RoleRepository(EcoConectaDBContext context) => _context = context;

    public IQueryable<Role> Query() => _context.Set<Role>();
    public Task<List<Role>> GetAllAsync() => Query().ToListAsync();
    public Task<Role?> GetByIdAsync(long id) => Query().FirstOrDefaultAsync(r => r.IdRol == id);

    public async Task AddAsync(Role entity) { _context.Set<Role>().Add(entity); await _context.SaveChangesAsync(); }
    public async Task UpdateAsync(Role entity) { _context.Set<Role>().Update(entity); await _context.SaveChangesAsync(); }
    public async Task DeleteAsync(Role entity) { _context.Set<Role>().Remove(entity); await _context.SaveChangesAsync(); }
}
