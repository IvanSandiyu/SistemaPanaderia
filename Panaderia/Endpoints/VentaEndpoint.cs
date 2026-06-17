
using Microsoft.AspNetCore.Mvc;
using Panaderia.Application.DTOs;
using Panaderia.Application.Interfaces;
using Panaderia.Domain.Entidades;

namespace Panaderia.WebApi.Endpoints
{
    public class VentaEndpoint : IEndpointDefinition
    {
        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            var ventaGroup = app.MapGroup("/api/venta").WithOpenApi();
            //.RequireAuthorization();

            ventaGroup.MapPost("/generarventa", GenerarVenta)
                .WithName("generarVenta")
                .WithOpenApi();

            ventaGroup.MapGet("/historialventas", HistorialVentas)
                .WithName("historialVentas")
                .WithOpenApi();
        }
        
        public async Task<bool> GenerarVenta(VentaDto venta, IVentaService _service)
        {
            if (venta is null)
                return false;

            return await _service.VentaRealizada(venta);
        }
        
        public async Task<IResult> HistorialVentas(DateTime? desde, DateTime? hasta,IVentaService _service)
        {
            var listVentas = await  _service.HistorialVentas(desde,hasta);
            return Results.Ok(listVentas);
        }
    }
}
