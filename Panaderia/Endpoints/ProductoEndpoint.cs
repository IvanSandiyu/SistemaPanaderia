using Microsoft.AspNetCore.Mvc;
using Panaderia.Application.Interfaces;
using Panaderia.Shared.DTOs.Productos;

namespace Panaderia.WebApi.Endpoints
{
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

        public async Task<IResult> CrearProducto(ProductoDTO dto, IProductoService service)
        {
            var creado = await service.CrearAsync(dto);

            if (!creado)
                return Results.BadRequest("No fue posible crear el producto.");

            return Results.Created($"/api/productos/{dto.Nombre}", dto);
        }

        public async Task<IResult> VerProductos(int? pagina, IProductoService service)
        {
            var productos = await service.ObtenerTodosAsync(pagina);

            return Results.Ok(productos);
        }

        public async Task<IResult> ProductoPorCodigo(int id, IProductoService service)
        {
            if (id <= 0)
                return Results.BadRequest("Id inválido.");

            var producto = await service.ObtenerPorIdAsync(id);

            if (producto is null)
                return Results.NotFound("Producto no encontrado.");

            return Results.Ok(producto);
        }

        public async Task<IResult> ActualizarProducto(int id, ProductoDTO p, IProductoService service)
        {
            if (id <= 0)
                return Results.BadRequest("Id inválido.");

            var actualizado = await service.ActualizarAsync(id, p);

            if (!actualizado)
                return Results.NotFound("Producto no encontrado.");

            return Results.NoContent();
        }

        public async Task<IResult> OcultarProducto(int id, IProductoService service)
        {
            if (id <= 0)
                return Results.BadRequest("Id inválido.");

            var eliminado = await service.OcultarProducto(id);

            if (!eliminado)
                return Results.NotFound("Producto no encontrado.");

            return Results.NoContent();
        }
    }
}
