
using Panaderia.Application.Interfaces;

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

        public async Task<IResult> VentasDiarias(IDashboardService service)
        {
            var response = await service.VentasDiarias();
            return Results.Ok(response);
        }

        public async Task<IResult> MasVendidos(IDashboardService service)
        {
            var lista = await service.ProductosMasVendidos();
            return Results.Ok(lista);
        }

        public async Task<IResult> MetodoPago(IDashboardService service)
        {
            var metodos = await service.MetodoDePago();
            return Results.Ok(metodos);
        }

        public async Task<IResult> VentasHoy(IDashboardService service)
        {
            var ventasHoy = await service.VentasHoy();
            return Results.Ok(ventasHoy);
        }

        public async Task<IResult> MasVendidosPorDia(IDashboardService service)
        {
            var metodos = await service.VentasPorDia();
            return Results.Ok(metodos);
        }

        public async Task<IResult> Ganancias(IDashboardService service)
        {
            var ganancia = await service.Ganancias();
            return Results.Ok(ganancia);
        }
    }
}
