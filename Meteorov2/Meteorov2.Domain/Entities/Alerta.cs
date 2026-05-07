namespace Meteorov2.Domain.Entities;

public class Alerta
{
    public int Id { get; set; }
    public string Mensaje { get; set; } = string.Empty;
    public string NivelRiesgo { get; set; } = string.Empty;
    public DateTime FechaEmision { get; set; }

    // Relación con Estación
    public int EstacionId { get; set; }
    public Estacion? Estacion { get; set; }
}