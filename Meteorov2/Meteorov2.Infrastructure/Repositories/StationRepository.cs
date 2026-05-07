using Meteorov2.Application.Interfaces;
using Meteorov2.Domain.Entities;
// Esta es la ruta exacta según tu imagen
using Meteorov2.Infrastructure.Persistence.Contexts; 

namespace Meteorov2.Infrastructure.Repositories;

public class StationRepository : IStationRepository
{
    private readonly ApplicationDbContext _context;

    public StationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Estacion estacion)
    {
        // Usamos "Estaciones" porque así está definido en tu línea 13 de la imagen
        await _context.Estaciones.AddAsync(estacion);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}