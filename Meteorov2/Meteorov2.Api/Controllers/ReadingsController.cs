using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Meteorov2.Domain.Entities;
using Meteorov2.Infrastructure.Persistence.Contexts;

namespace Meteorov2.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReadingsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public ReadingsController(ApplicationDbContext context) { _context = context; }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Lectura>>> Get() 
        => await _context.Lecturas.ToListAsync();

    [HttpPost]
    public async Task<ActionResult> Post(Lectura lectura) {
        _context.Lecturas.Add(lectura);
        await _context.SaveChangesAsync();
        return Ok();
    }

    // --- MÉTODO PARA ELIMINAR LECTURAS ---
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        // Buscamos la lectura por su ID
        var lectura = await _context.Lecturas.FindAsync(id);

        // Si no existe, devolvemos error 404
        if (lectura == null)
        {
            return NotFound();
        }

        // Eliminamos el registro de PostgreSQL
        _context.Lecturas.Remove(lectura);
        await _context.SaveChangesAsync();

        return NoContent(); // Éxito (204 No Content)
    }
}