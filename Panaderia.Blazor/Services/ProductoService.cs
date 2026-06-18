using Panaderia.Blazor.Models;
using System.Net.Http.Json;

namespace Panaderia.Blazor.Services
{
    public class ProductoService
    {
        private readonly HttpClient _http;

        public ProductoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ProductoDto>> ObtenerTodos()
        {
            return await _http.GetFromJsonAsync<List<ProductoDto>>(
                "api/stock/productos")
                ?? new();
        }

        public async Task<ProductoDto> ObtenerPorId(int id)
        {
            return await _http.GetFromJsonAsync<ProductoDto>($"api/stock/{id}") ?? new();
        }
        public async Task<bool> Actualizar(int id, ProductoDto dto)
        {
            var response = await _http.PostAsJsonAsync(
                $"api/stock/modificarproducto/{id}",
                dto);

            return response.IsSuccessStatusCode;
        }
    }
}
