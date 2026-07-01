
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Panaderia.Application.Interfaces;
using Panaderia.Shared.DTOs.Productos;
using Panaderia.Shared.Ventas;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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

            dashGroup.MapGet("/masvendidos-pordia", MasVendidosPorDia)
                .WithOpenApi();

            dashGroup.MapGet("/metodos-pagos", MetodoPago)
                .WithOpenApi();

            dashGroup.MapGet("/ventashoy", VentasHoy)
                .WithOpenApi();

            dashGroup.MapGet("/ganancias", Ganancias)
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

        public async Task<List<MetodoPagoDto>> MetodoPago(IDashboardService service)
        {
            var metodos = await service.MetodoDePago();
            return metodos;
        }

        public async Task<List<VentaDiariaDto>> VentasHoy(IDashboardService service)
        {
            var lista = await service.VentasDiarias();
            return lista;
        }

        public async Task<List<DetalleVentaHistorialDto>> MasVendidosPorDia(IDashboardService service)
        {
            var lista = await service.VentasPorDia();
            return lista;
        }

        public async Task<decimal?> Ganancias(IDashboardService service)
        {
            var ganancia = await service.Ganancias();
            return ganancia;
        }
    }
}
