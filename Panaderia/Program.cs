using Microsoft.EntityFrameworkCore;
using Panaderia.Application.Interfaces;
using Panaderia.Infrastructure.EntityFramework;
using Panaderia.WebApi.Endpoints;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar servicios
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Configurar Base de Datos
builder.Services.AddDbContext<PanaderiaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. Registrar el contexto para la Inyección de Dependencias
builder.Services.AddScoped<IApplicationDbContext>(provider =>
    provider.GetRequiredService<PanaderiaDbContext>());

var app = builder.Build();

// 4. Configurar el pipeline
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Comentamos la redirección si te daba error en local
// app.UseHttpsRedirection(); 

// 5. REGISTRO AUTOMÁTICO DE ENDPOINTS
// Escanea el ensamblado actual en busca de clases que implementan IEndpointDefinition
var endpointDefinitions = typeof(Program).Assembly.GetTypes()
    .Where(t => typeof(IEndpointDefinition).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
    .Select(Activator.CreateInstance)
    .Cast<IEndpointDefinition>();

foreach (var endpointDef in endpointDefinitions) {
    endpointDef.MapEndpoints(app);
}

app.Run();
