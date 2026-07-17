
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

        private async Task<IResult> VentasDiarias(IDashboardService service)
        {
            try {
                var response = await service.VentasDiarias();
                return Results.Ok(response);
            } catch (Exception ex) {
                return Results.Problem(ex.Message);
            }

            
            
        }

        public async Task<IResult> MasVendidos(IDashboardService service)
        {
            try {
                var lista = await service.ProductosMasVendidos();
                return Results.Ok(lista);

            }
            catch (Exception ex) {
                return Results.Problem(ex.Message);
            }
            
        }

        public async Task<IResult> MetodoPago(IDashboardService service)
        {
            try {
                var metodos = await service.MetodoDePago();
                return Results.Ok(metodos);
            } 
            catch(Exception ex) {
                return Results.Problem(ex.Message);
            }
            
        }

        public async Task<IResult> VentasHoy(IDashboardService service)
        {
            try {
                var metodos = await service.VentasDiarias();
                return Results.Ok(metodos);
            } catch (Exception ex) {
                return Results.Problem(ex.Message);
            }
            
        }

        public async Task<IResult> MasVendidosPorDia(IDashboardService service)
        {
            try {
                var metodos = await service.VentasPorDia();
                return Results.Ok(metodos);
            }
            catch(Exception ex) {
                return Results.Problem(ex.Message); 
            }
        }

        public async Task<decimal?> Ganancias(IDashboardService service)
        {
            var ganancia = await service.Ganancias();
            return ganancia;
        }
    }
}
