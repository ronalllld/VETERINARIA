using VeterinariaApi.Models;
using VeterinariaApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n del DbContext con la cadena de conexi�n desde appsettings.json
builder.Services.AddDbContext<VeterinariaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VeterinariaDb")));

// Registro de los servicios para inyecci�n de dependencias
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<MascotaService>();
builder.Services.AddScoped<CitaService>();
builder.Services.AddScoped<ServicioService>();

// Configuraci�n de controladores y Swagger para la documentaci�n de la API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuraci�n del middleware para desarrollo
if (app.Environment.IsDevelopment())
{
    // Activa Swagger en modo desarrollo
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirecci�n de HTTP a HTTPS
app.UseHttpsRedirection();

// Middleware para la autorizaci�n
app.UseAuthorization();

// Mapea los controladores, asegurando que est�n disponibles en la API
app.MapControllers();

// Ejecuta la aplicaci�n
app.Run();
