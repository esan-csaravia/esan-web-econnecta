using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Infrastructure.Data;

namespace web.econecta.dpa.core.Infrastructure.Repositories;

public class AccionesAdministrativasUsuarioRepository
{
    private readonly EcoConectaDBContext _context;
    public AccionesAdministrativasUsuarioRepository(EcoConectaDBContext context) => _context = context;

    public IQueryable<AccionesAdministrativasUsuario> Query() => _context.Set<AccionesAdministrativasUsuario>();

    public Task<List<AccionesAdministrativasUsuario>> GetAllAsync() => Query().ToListAsync();
    public Task<AccionesAdministrativasUsuario?> GetByIdAsync(long id) => Query().FirstOrDefaultAsync(e => e.IdAccion == id);

    public async Task AddAsync(AccionesAdministrativasUsuario entity)
    {
        _context.Set<AccionesAdministrativasUsuario>().Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(AccionesAdministrativasUsuario entity)
    {
        _context.Set<AccionesAdministrativasUsuario>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(AccionesAdministrativasUsuario entity)
    {
        _context.Set<AccionesAdministrativasUsuario>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}
