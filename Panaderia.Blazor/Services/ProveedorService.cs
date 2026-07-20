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
                $"api/proveedores/lista-proveedores")
                ?? new();
        }
        public async Task<ProveedorDTO> ObtenerPorId(int id)
        {
            return await _http.GetFromJsonAsync<ProveedorDTO>(
                $"api/proveedores/proveedorporid/{id}")
                ?? new();
        }

        public async Task<bool> CrearProveedor(ProveedorDTO dto)
        {
            var response = await _http.PostAsJsonAsync(
                "api/proveedores/crearproveedor",
                dto);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EditarProveedor(int id,  ProveedorDTO dto)
        {
            var response = await _http.PutAsJsonAsync($"api/proveedores/editarproveedor/{id}",dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EstadoProveedor(int id)
        {
            var response = await _http.PutAsJsonAsync($"api/proveedores/estadoproveedor/{id}","");

            return response.IsSuccessStatusCode;
        }


    }
}
