using Panaderia.Shared.DTOs.Productos;
using Panaderia.Shared.DTOs.Proveedores;
using System.Net.Http.Json;

namespace Panaderia.Blazor.Services
{
    public class ProveedorService
    {
        private readonly HttpClient _http;

        public ProveedorService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ProveedorDTO>> ObtenerTodos()
        {
            return await _http.GetFromJsonAsync<List<ProveedorDTO>>(
                "api/proveedores")
                ?? new();
        }


    }
}
