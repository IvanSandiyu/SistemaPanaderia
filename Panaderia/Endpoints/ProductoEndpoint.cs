using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Panaderia.Application.Interfaces;
using Panaderia.Domain.Entidades.Productos;
using Panaderia.Shared.DTOs.Productos;
using System.ComponentModel;

namespace Panaderia.WebApi.Endpoints
{
    //LO IDEAL SERIA TENER MIDDLEWARE GLOBAL Y SACAR LOS TRY CATCH
    public class ProductoEndpoint : IEndpointDefinition
    {
        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            var stockGroup = app.MapGroup("/api/stock").WithOpenApi();
            //.RequireAuthorization();

            stockGroup.MapGet("/{id:int}", ProductoPorCodigo)
               .WithOpenApi();

            stockGroup.MapGet("/productos", VerProductos);

            stockGroup.MapPost("/crearproductos", CrearProducto)
               .WithName("crearProductos")
               .WithOpenApi();

            stockGroup.MapPost("/modificarproducto/{id:int}", ActualizarProducto)
               .WithName("modificarProductos")
               .WithOpenApi();

            stockGroup.MapPut("/{id:int}", OcultarProducto)
               .WithOpenApi();

           
        }
        
        public async Task<IResult> CrearProducto([FromBody] ProductoDTO dto, IProductoService _service)
        {
            try {
                var creado = await _service.CrearAsync(dto);

                if (!creado)
                    return Results.BadRequest("No fue posible crear el producto.");

                return Results.Created($"/api/productos/{dto.Nombre}", dto);
            } catch (Exception ex) {
                return Results.Problem(ex.Message);
            }

        }

        public async Task<IResult> VerProductos(IProductoService service,int? pagina)
        {
            var productos = await service.ObtenerTodosAsync(pagina);

            return Results.Ok(productos);
        }

        public async Task<IResult> ProductoPorCodigo(int id, IProductoService _service)
        {
            try {
                if (id <= 0)
                    return Results.BadRequest("Id inválido.");

                var producto = await _service.ObtenerPorIdAsync(id);

                if (producto is null)
                    return Results.NotFound("Producto no encontrado.");

                return Results.Ok(producto);
            } catch (Exception ex) {
                return Results.Problem(ex.Message);
            }
        }
        
        public async Task<IResult> ActualizarProducto(int id, [FromBody] ProductoDTO p, IProductoService _service)
        {
            try {
                if (id <= 0)
                    return Results.BadRequest("Id inválido.");

                var actualizado = await _service.ActualizarAsync(id, p);

                if (!actualizado)
                    return Results.NotFound("Producto no encontrado.");

                return Results.NoContent();
            } catch (Exception ex) {
                return Results.Problem(ex.Message);
            }
        }

        public async Task<IResult> OcultarProducto(int id, IProductoService _service)
        {

            try {
                if (id <= 0)
                    return Results.BadRequest("Id inválido.");

                var eliminado = await _service.OcultarProducto(id);

                if (!eliminado)
                    return Results.NotFound("Producto no encontrado.");

                return Results.NoContent();
            } catch (Exception ex) {
                return Results.Problem(ex.Message);
            }

        }
    }

}
