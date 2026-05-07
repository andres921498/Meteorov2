using Microsoft.EntityFrameworkCore;
using Meteorov2.Application.Interfaces;
using Meteorov2.Infrastructure.Persistence.Contexts;

namespace Meteorov2.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly ApplicationDbContext _context;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
    public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);
    public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);
    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

    public async Task Delete(int id)
{
    // Esto busca el registro por su ID en la base de datos
    var entity = await _context.Set<T>().FindAsync(id);
    
    // Si lo encuentra, lo marca para ser borrado
    if (entity != null)
    {
        _context.Set<T>().Remove(entity);
    }
}
}