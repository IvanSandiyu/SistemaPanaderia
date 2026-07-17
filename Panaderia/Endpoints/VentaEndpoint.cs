using Microsoft.AspNetCore.Mvc;
using Panaderia.Application.Interfaces;
using Panaderia.Domain.Entidades;
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
        }
        //Cambiar A results(bad request,ok,etc)
        public async Task<IResult> GenerarVenta(VentaDto venta, IVentaService _service)
        {
            try {
                if (venta is null)
                    return Results.Problem();

                var response = await _service.VentaRealizada(venta);
                return Results.Ok(response);

            }catch(Exception ex) {
                return Results.Problem(ex.Message);
            }
        }
        
        public async Task<IResult> HistorialVentas(DateTime? desde, DateTime? hasta, int? pagina,IVentaService _service)
        {
            try {
                var listVentas = await _service.HistorialVentas(desde, hasta, pagina);
                return Results.Ok(listVentas);
            }
            catch(Exception ex) { 
                return Results.Problem(ex.Message);
            }
            
        }
    }
}
