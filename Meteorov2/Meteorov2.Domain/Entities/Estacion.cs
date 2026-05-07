namespace Meteorov2.Domain.Entities;

public class Estacion
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public double Latitud { get; set; }
    public double Longitud { get; set; }
    public string Barrio { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;

    // Relación: Una estación tiene muchos sensores
    public ICollection<Sensor> Sensores { get; set; } = new List<Sensor>();
}