using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Meteorov2.Domain.Entities;
using Meteorov2.Infrastructure.Persistence.Contexts;

namespace Meteorov2.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlertsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public AlertsController(ApplicationDbContext context) { _context = context; }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Alerta>>> Get() 
        => await _context.Alertas.ToListAsync();

    [HttpPost]
    public async Task<ActionResult> Post(Alerta alerta) {
        _context.Alertas.Add(alerta);
        await _context.SaveChangesAsync();
        return Ok();
    }

    // --- MÉTODO PARA ELIMINAR ALERTAS ---
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        // Buscamos la alerta por su ID
        var alerta = await _context.Alertas.FindAsync(id);

        // Si no existe en PostgreSQL, devolvemos error 404
        if (alerta == null)
        {
            return NotFound();
        }

        // Eliminamos el registro
        _context.Alertas.Remove(alerta);
        await _context.SaveChangesAsync();

        return NoContent(); // Éxito (204 No Content)
    }
}