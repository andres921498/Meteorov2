using Microsoft.EntityFrameworkCore;
using Meteorov2.Domain.Entities;

namespace Meteorov2.Infrastructure.Persistence.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Estas líneas le dicen a Entity Framework que cree las tablas en Postgres
    public DbSet<Estacion> Estaciones { get; set; } = null!;
    public DbSet<Sensor> Sensores { get; set; } = null!;
    public DbSet<Lectura> Lecturas { get; set; } = null!;
    public DbSet<Alerta> Alertas { get; set; } = null!;
    public DbSet<Usuario> Usuarios { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Aquí configuramos que el ID de Estación sea autoincremental
        modelBuilder.Entity<Estacion>().HasKey(e => e.Id);
    }
}