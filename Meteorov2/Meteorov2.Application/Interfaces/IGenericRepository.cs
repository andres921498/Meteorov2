namespace Meteorov2.Application.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task Delete(int id); // <--- Método agregado
    Task SaveChangesAsync();
}