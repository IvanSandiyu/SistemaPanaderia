using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Panaderia.Application.DTOs;
using Panaderia.Application.Interfaces;
using Panaderia.Domain.Entidades;

namespace Panaderia.WebApi.Endpoints
{
    public class StockEndpoint : IEndpointDefinition
    {
        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            var stockGroup = app.MapGroup("/api/stock")
                            .RequireAuthorization();

            //stockGroup.MapGet("/{codigo:int}", stockPorCodigo)
            //   .WithName("Stock")
            //   .WithOpenApi();

            //stockGroup.MapGet("/", stock)
            //   .WithName("getStockName")
            //   .WithOpenApi();

            stockGroup.MapPost("/productos", CrearProducto)
               .WithName("crearProductos")
               .WithOpenApi();
        }
        
        public async Task<IResult> CrearProducto([FromBody] ProductoDTO dto, IApplicationDbContext _db)
        {
            try {
                var producto = new Producto
                {
                    Nombre = dto.Nombre,
                    PrecioCompra = dto.PrecioCompra,
                    PrecioVenta = dto.PrecioVenta,
                };
                _db.Productos.Add(producto);
                await _db.SaveChangesAsync();
                return Results.Created($"/api/stock/productos/{producto.Id}", producto);

            } catch (Exception ex) {
                return Results.Problem(ex.Message);
            }

        }
    }

}
