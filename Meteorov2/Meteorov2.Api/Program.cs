using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Meteorov2.Application.Interfaces;
using Meteorov2.Infrastructure.Repositories;
using Meteorov2.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuración de la conexión a PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. CONFIGURACIÓN DE KEYCLOAK (Seguridad)
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // Asegúrate de que este sea el nombre de tu Realm en Keycloak (puerto 8080)
        options.Authority = "http://localhost:8080/realms/Meteorov2"; 
        options.RequireHttpsMetadata = false; // Solo para desarrollo local
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = true
        };
    });

builder.Services.AddAuthorization();

// 3. REGISTRO DE SERVICIOS Y REPOSITORIOS
builder.Services.AddControllers(); // Necesario para que funcionen los Controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Swagger es mejor para probar tokens que OpenApi solo

// Registro Genérico: Esto habilita todas las tablas (Estacion, Sensor, Lectura, etc.)
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Mantengo tus servicios específicos por si los usas, pero el Genérico es más rápido
builder.Services.AddScoped<IStationRepository, StationRepository>();
builder.Services.AddScoped<Meteorov2.Application.Services.StationService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

// 4. PIPELINE DE LA APLICACIÓN
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAngular");

// EL ORDEN AQUÍ ES CRÍTICO PARA EL PROYECTO FINAL
app.UseAuthentication(); // Primero identifica quién es el usuario
app.UseAuthorization();  // Luego revisa si tiene permiso

app.MapControllers(); // Esto mapea tu StationsController.cs

app.Run();