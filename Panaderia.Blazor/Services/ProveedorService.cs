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
                "api/proveedores/lista-proveedores")
                ?? new();
        }
        public async Task<bool> CrearProveedor(ProveedorDTO dto)
        {
            var response = await _http.PostAsJsonAsync(
                "api/proveedores/crearproveedor",
                dto);

            return response.IsSuccessStatusCode;
        }


    }
}
