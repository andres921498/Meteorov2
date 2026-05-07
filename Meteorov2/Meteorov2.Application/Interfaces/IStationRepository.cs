using Meteorov2.Domain.Entities;

namespace Meteorov2.Application.Interfaces;

public interface IStationRepository
{
    Task AddAsync(Estacion estacion);
    Task SaveChangesAsync();
}