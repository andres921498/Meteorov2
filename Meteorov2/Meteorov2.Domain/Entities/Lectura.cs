namespace Meteorov2.Domain.Entities;

public class Lectura
{
    public int Id { get; set; }
    public double Valor { get; set; }
    public DateTime FechaHora { get; set; }

    // Relación con Sensor
    public int SensorId { get; set; }
    public Sensor? Sensor { get; set; }
}