using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Infrastructure.Data;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.core.Infrastructure.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly EcoConectaDBContext _context;
    public CategoriaRepository(EcoConectaDBContext context) => _context = context;

    public IQueryable<Categoria> Query() => _context.Set<Categoria>();
    public Task<List<Categoria>> GetAllAsync() => Query().ToListAsync();
    public Task<Categoria?> GetByIdAsync(long id) => Query().FirstOrDefaultAsync(c => c.IdCategoria == id);

    public async Task AddAsync(Categoria entity) { _context.Set<Categoria>().Add(entity); await _context.SaveChangesAsync(); }
    public async Task UpdateAsync(Categoria entity) { _context.Set<Categoria>().Update(entity); await _context.SaveChangesAsync(); }
    public async Task DeleteAsync(Categoria entity) { _context.Set<Categoria>().Remove(entity); await _context.SaveChangesAsync(); }
}
