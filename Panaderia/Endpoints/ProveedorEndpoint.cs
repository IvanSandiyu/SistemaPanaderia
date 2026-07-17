
using Microsoft.AspNetCore.Mvc;
using Panaderia.Application.Interfaces;
using Panaderia.Domain.Entidades.Proveedores;
using Panaderia.Shared.DTOs.Proveedores;

namespace Panaderia.WebApi.Endpoints
{
    public class ProveedorEndpoint : IEndpointDefinition
    {
        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            var provGroup = app.MapGroup("api/proveedores")
                .WithOpenApi();

            provGroup.MapGet("/lista-proveedores", ObtenerTodos)
                .WithOpenApi();

            provGroup.MapPost("/crearproveedor", CrearProveedor)
                .WithOpenApi();
        }

        public async Task<IResult> ObtenerTodos(IProveedorService service)
        {
            try {
                var response = await service.ObtenerTodos();
                return Results.Ok(response);
            } catch(Exception ex) {
                return Results.Problem(ex.Message);
            }
        }

       public async Task<IResult> CrearProveedor([FromBody] ProveedorDTO dto,IProveedorService service)
        {
            try {
                var response = await service.CrearProveedor(dto);
                return Results.Ok(response); 
            }
            catch(Exception ex) {
                return Results.Problem(ex.Message);
            }
        }
    }
}
