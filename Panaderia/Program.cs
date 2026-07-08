using Microsoft.EntityFrameworkCore;
using Panaderia.Application.Interfaces;
using Panaderia.Application.Services;
using Panaderia.Infrastructure.EntityFramework;
using Panaderia.WebApi.Endpoints;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PanaderiaDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IApplicationDbContext>(
    provider => provider.GetRequiredService<PanaderiaDbContext>());

builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IVentaService, VentaService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IProveedorService, ProveedorService>();



//Habilitamos el CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorPolicy", policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:5088",
                "https://localhost:7199")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseHttpsRedirection();
app.UseCors("BlazorPolicy");

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

var endpointDefinitions = typeof(Program).Assembly.GetTypes()
    .Where(t =>
        typeof(IEndpointDefinition).IsAssignableFrom(t)
        && !t.IsInterface
        && !t.IsAbstract)
    .Select(Activator.CreateInstance)
    .Cast<IEndpointDefinition>();

foreach (var endpointDef in endpointDefinitions) {
    endpointDef.MapEndpoints(app);
}

app.Run();
