namespace Panaderia.WebApi.Endpoints
{
    public interface IEndpointDefinition
    {
        void MapEndpoints(IEndpointRouteBuilder app);
    }
}
