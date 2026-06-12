
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
        }
        
        public async Task<bool> GenerarVenta(VentaDto venta, IVentaService _service)
        {
            if (venta is null)
                return false;

            return await _service.VentaRealizada(venta);
        }
        
    }
}
