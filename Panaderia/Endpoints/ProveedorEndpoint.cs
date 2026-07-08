
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

            provGroup.MapGet("/proveedores", ObtenerTodos)
                .WithOpenApi();
        }

        public async Task<List<Proveedor>> ObtenerTodos(IProveedorService service)
        {
            var response = await service.ObtenerTodos();
            return response.ToList();
        }
    }
}
