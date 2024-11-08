using VeterinariaApi.Models;
using VeterinariaApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración del DbContext con la cadena de conexión desde appsettings.json
builder.Services.AddDbContext<VeterinariaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VeterinariaDb")));

// Registro de los servicios para inyección de dependencias
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<MascotaService>();
builder.Services.AddScoped<CitaService>();
builder.Services.AddScoped<ServicioService>();

// Configuración de controladores y Swagger para la documentación de la API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración del middleware para desarrollo
if (app.Environment.IsDevelopment())
{
    // Activa Swagger en modo desarrollo
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirección de HTTP a HTTPS
app.UseHttpsRedirection();

// Middleware para la autorización
app.UseAuthorization();

// Mapea los controladores, asegurando que estén disponibles en la API
app.MapControllers();

// Ejecuta la aplicación
app.Run();
