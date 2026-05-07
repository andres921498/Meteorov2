using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Meteorov2.Domain.Entities;
using Meteorov2.Infrastructure.Persistence.Contexts;

namespace Meteorov2.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SensorsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    
    public SensorsController(ApplicationDbContext context) 
    { 
        _context = context; 
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Sensor>>> Get() 
        => await _context.Sensores.ToListAsync();

    [HttpPost]
    public async Task<ActionResult> Post(Sensor sensor) 
    {
        _context.Sensores.Add(sensor);
        await _context.SaveChangesAsync();
        return Ok();
    }

    // --- ESTO ES LO QUE FALTABA ---
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        // Buscamos el sensor por su ID
        var sensor = await _context.Sensores.FindAsync(id);

        // Si no existe, devolvemos 404
        if (sensor == null)
        {
            return NotFound();
        }

        // Lo eliminamos de la base de datos PostgreSQL
        _context.Sensores.Remove(sensor);
        await _context.SaveChangesAsync();

        return NoContent(); // Éxito (204 No Content)
    }
}