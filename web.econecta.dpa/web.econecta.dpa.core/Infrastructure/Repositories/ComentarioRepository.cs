using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Infrastructure.Data;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.core.Infrastructure.Repositories;

public class ComentarioRepository : IComentarioRepository
{
    private readonly EcoConectaDBContext _context;
    public ComentarioRepository(EcoConectaDBContext context) => _context = context;

    public IQueryable<Comentario> Query() => _context.Set<Comentario>();
    public Task<List<Comentario>> GetAllAsync() => Query().ToListAsync();
    public Task<Comentario?> GetByIdAsync(long id) => Query().FirstOrDefaultAsync(c => c.IdComentario == id);

    public async Task AddAsync(Comentario entity) { _context.Set<Comentario>().Add(entity); await _context.SaveChangesAsync(); }
    public async Task UpdateAsync(Comentario entity) { _context.Set<Comentario>().Update(entity); await _context.SaveChangesAsync(); }
    public async Task DeleteAsync(Comentario entity) { _context.Set<Comentario>().Remove(entity); await _context.SaveChangesAsync(); }
}
