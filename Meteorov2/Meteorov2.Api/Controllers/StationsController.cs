using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Meteorov2.Application.Interfaces;
using Meteorov2.Domain.Entities;

namespace Meteorov2.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous] 
public class StationsController : ControllerBase
{
    private readonly IGenericRepository<Estacion> _estaciones;
    private readonly IGenericRepository<Sensor> _sensores;
    private readonly IGenericRepository<Lectura> _lecturas;

    public StationsController(
        IGenericRepository<Estacion> estaciones,
        IGenericRepository<Sensor> sensores,
        IGenericRepository<Lectura> lecturas)
    {
        _estaciones = estaciones;
        _sensores = sensores;
        _lecturas = lecturas;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _estaciones.GetAllAsync());

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Estacion entidad)
    {
        await _estaciones.AddAsync(entidad);
        await _estaciones.SaveChangesAsync();
        return Ok(entidad);
    }

    // --- BORRAR ESTACIÓN CORREGIDO ---
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        // Pasamos directamente el 'id' al repositorio
        await _estaciones.Delete(id); 
        await _estaciones.SaveChangesAsync();
        return NoContent();
    }

    [HttpPost("sensores")]
    public async Task<IActionResult> PostSensor([FromBody] Sensor entidad)
    {
        await _sensores.AddAsync(entidad);
        await _sensores.SaveChangesAsync();
        return Ok(entidad);
    }

    // --- BORRAR SENSOR CORREGIDO ---
    [HttpDelete("sensores/{id}")]
    public async Task<IActionResult> DeleteSensor(int id)
    {
        await _sensores.Delete(id);
        await _sensores.SaveChangesAsync();
        return NoContent();
    }

    [HttpPost("lecturas")]
    public async Task<IActionResult> PostLectura([FromBody] Lectura entidad)
    {
        await _lecturas.AddAsync(entidad);
        await _lecturas.SaveChangesAsync();
        return Ok(entidad);
    }

    // --- BORRAR LECTURA CORREGIDO ---
    [HttpDelete("lecturas/{id}")]
    public async Task<IActionResult> DeleteLectura(int id)
    {
        await _lecturas.Delete(id);
        await _lecturas.SaveChangesAsync();
        return NoContent();
    }
}