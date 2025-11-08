using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web.econecta.dpa.core.Core.Entities;
using web.econecta.dpa.core.Infrastructure.Data;
using web.econecta.dpa.core.Core.Interfaces;

namespace web.econecta.dpa.core.Infrastructure.Repositories;

public class NotificacioneRepository : INotificacioneRepository
{
    private readonly EcoConectaDBContext _context;
    public NotificacioneRepository(EcoConectaDBContext context) => _context = context;

    public IQueryable<Notificacione> Query() => _context.Set<Notificacione>();
    public Task<List<Notificacione>> GetAllAsync() => Query().ToListAsync();
    public Task<Notificacione?> GetByIdAsync(long id) => Query().FirstOrDefaultAsync(n => n.IdNotificacion == id);

    public async Task AddAsync(Notificacione entity) { _context.Set<Notificacione>().Add(entity); await _context.SaveChangesAsync(); }
    public async Task UpdateAsync(Notificacione entity) { _context.Set<Notificacione>().Update(entity); await _context.SaveChangesAsync(); }
    public async Task DeleteAsync(Notificacione entity) { _context.Set<Notificacione>().Remove(entity); await _context.SaveChangesAsync(); }
}
