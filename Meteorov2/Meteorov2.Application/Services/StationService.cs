using Meteorov2.Application.Interfaces;
using Meteorov2.Domain.Entities;

namespace Meteorov2.Application.Services;

public class StationService
{
    private readonly IStationRepository _repository;

    public StationService(IStationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Estacion> CreateStation(Estacion estacion)
    {
        await _repository.AddAsync(estacion);
        await _repository.SaveChangesAsync();
        return estacion;
    }
}