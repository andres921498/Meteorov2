namespace Meteorov2.Domain.Entities;

public class Sensor
{
    public int Id { get; set; }
    public string TipoSensor { get; set; } = string.Empty;
    public string UnidadMedida { get; set; } = string.Empty;
    
    // Relación con Estación
    public int EstacionId { get; set; }
    public Estacion? Estacion { get; set; }

    // Relación: Un sensor genera muchas lecturas
    public ICollection<Lectura> Lecturas { get; set; } = new List<Lectura>();
}