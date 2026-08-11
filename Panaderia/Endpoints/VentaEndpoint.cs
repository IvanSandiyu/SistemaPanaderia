using Panaderia.Application.Interfaces;
using Panaderia.Shared.DTOs.Ventas;

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

            ventaGroup.MapGet("/historialventas/{pagina:int}", HistorialVentas)
                .WithName("historialVentas")
                .WithOpenApi();

            ventaGroup.MapGet("/ventas/{pag:int}", ListaVentas);
        }

        public async Task<IResult> GenerarVenta(VentaDto venta, IVentaService service)
        {
            if (venta is null)
                return Results.BadRequest("La venta no puede ser nula.");

            var response = await service.VentaRealizada(venta);

            return response
                ? Results.Ok(response)
                : Results.BadRequest("No hay stock suficiente para realizar la venta.");
        }

        public async Task<IResult> HistorialVentas(DateTime? desde, DateTime? hasta, int? pagina, IVentaService service)
        {
            var listVentas = await service.HistorialVentas(desde, hasta, pagina);
            return Results.Ok(listVentas);
        }

        private async Task<IResult> ListaVentas(int? pag, IVentaService service)
        {
            var ventas = await service.ListaVentas(pag);

            return Results.Ok(ventas);
        }
    }
}
