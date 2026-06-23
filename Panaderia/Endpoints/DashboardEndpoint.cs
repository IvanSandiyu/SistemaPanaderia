
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Panaderia.Application.DTOs;
using Panaderia.Application.Interfaces;
using System.ComponentModel;

namespace Panaderia.WebApi.Endpoints
{
    public class DashboardEndpoint : IEndpointDefinition
    {
        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            var dashGroup = app.MapGroup("api/dashboard")
                .WithOpenApi(); 

            //dashGroup.MapGet("/ventasdiarias", VentasDiarias)
            //    .WithOpenApi();

            dashGroup.MapGet("/masvendidos", MasVendidos)
                .WithOpenApi();

            //dashGroup.MapGet("/metodos-pagos", MetodosPago)
            //    .WithOpenAp();
        }

        public async Task<List<ProductoMasVendidoDto>> MasVendidos(IDashboardService service)
        {
            var lista = await service.ProductosMasVendidos();
            return lista.ToList();
        }
    }
}
