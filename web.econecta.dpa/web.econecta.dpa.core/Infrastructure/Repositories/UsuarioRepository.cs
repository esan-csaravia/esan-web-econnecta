using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Infrastructure.Data;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.core.Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly EcoConectaDBContext _context;
    public UsuarioRepository(EcoConectaDBContext context) => _context = context;

    public IQueryable<Usuario> Query() => _context.Set<Usuario>();

    public Task<List<Usuario>> GetAllAsync() => Query().ToListAsync();

    public Task<Usuario?> GetByIdAsync(long id) => Query().FirstOrDefaultAsync(u => u.IdUsuario == id);

    public async Task AddAsync(Usuario entity)
    {
        _context.Usuarios.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Usuario entity)
    {
        _context.Usuarios.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Usuario entity)
    {
        _context.Usuarios.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public Task<Usuario?> GetByEmailAsync(string email) => Query().FirstOrDefaultAsync(u => u.Correo == email);
}
