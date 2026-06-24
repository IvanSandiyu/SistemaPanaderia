
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

            dashGroup.MapGet("/ventapordia", VentasDiarias)
                .WithOpenApi();

            dashGroup.MapGet("/masvendidos", MasVendidos)
                .WithOpenApi();

            dashGroup.MapGet("/metodos-pagos", MetodoPago)
                .WithOpenApi();
        }

        private async Task<List<VentaDiariaDto>> VentasDiarias(IDashboardService service)
        {
            var response = await service.VentasDiarias();
            return response.ToList();
        }

        public async Task<List<ProductoMasVendidoDto>> MasVendidos(IDashboardService service)
        {
            var lista = await service.ProductosMasVendidos();
            return lista.ToList();
        }

        public async Task<List<MetodoPagoDTO>> MetodoPago(IDashboardService service)
        {
            var metodos = await service.MetodoDePago();
            return metodos;
        }
    }
}
