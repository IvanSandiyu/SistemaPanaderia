using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Panaderia.Application.DTOs;
using Panaderia.Application.Interfaces;
using Panaderia.Domain.Entidades;
using System.ComponentModel;

namespace Panaderia.WebApi.Endpoints
{
    public class StockEndpoint : IEndpointDefinition
    {
        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            var stockGroup = app.MapGroup("/api/stock").WithOpenApi();
            //.RequireAuthorization();

            stockGroup.MapGet("/{id:int}", ProductoPorCodigo)
               .WithOpenApi();

            stockGroup.MapGet("/", VerProductos)
               .WithName("productos")
               .WithOpenApi();

            stockGroup.MapPost("/crearproductos", CrearProducto)
               .WithName("crearProductos")
               .WithOpenApi();

            stockGroup.MapPost("/modificarproducto/{id:int}", ActualizarProducto)
               .WithName("modificarProductos")
               .WithOpenApi();
        }
        
        public async Task<IResult> CrearProducto([FromBody] ProductoDTO dto, IProductoService _service)
        {
            try {
                var producto = new Producto
                {
                    Nombre = dto.Nombre,
                    PrecioCompra = dto.PrecioCompra,
                    PrecioVenta = dto.PrecioVenta,
                };
                if((await _service.CrearAsync(producto))){
                    return Results.Created($"/api/stock/productos/{producto.Id}", producto);
                }
                return Results.Problem("Hubo un problema al crear");

            } catch (Exception ex) {
                return Results.Problem(ex.Message);
            }

        }

        public async Task<List<Producto>> VerProductos(IProductoService _service)
        {
            List<Producto> productos;
            try {
                 productos = await _service.ObtenerTodosAsync();
                return productos;

            }catch(Exception ex) {
                return null;
            }
        }
        
        public async Task<Producto> ProductoPorCodigo(int id, IProductoService _service)
        {
            try {
                if (id <= 0)
                    return null;

                var p = await _service.ObtenerPorIdAsync(id);
                return p;

            } catch (Exception ex) {
                return null;
            }
        }
        
        public async Task<bool> ActualizarProducto(int id, [FromBody] ProductoDTO p, IProductoService _service)
        {
            try {
                if (id <= 0)
                    return false;

                if (await _service.ActualizarAsync(id, p))
                    return true;
                return false;

            }catch(Exception ex) {
                return false;
            }
        }
    }

}
