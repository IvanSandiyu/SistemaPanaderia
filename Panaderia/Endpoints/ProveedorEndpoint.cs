
using Panaderia.Application.Interfaces;
using Panaderia.Domain.Entidades.Proveedores;

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
    }
}
