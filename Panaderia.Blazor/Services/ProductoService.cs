using Panaderia.Shared.DTOs.Productos;
using Panaderia.Shared.DTOs.Reportes;
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

        public async Task<List<ProductoDTO>> ObtenerTodos()
        {
            return await _http.GetFromJsonAsync<List<ProductoDTO>>(
                "api/stock/productos")
                ?? new();
        }
        public async Task<List<ProductoDTO>> ObtenerTodos(int? pag = null)
        {
            string url = "api/stock/productos";

            if (pag.HasValue)
                url += $"?pagina={pag}";

            return await _http.GetFromJsonAsync<List<ProductoDTO>>(url)
                   ?? new();
        }


        public async Task<ProductoDTO> ObtenerPorId(int id)
        {
            return await _http.GetFromJsonAsync<ProductoDTO>($"api/stock/{id}") ?? new();
        }
        public async Task<bool> Actualizar(int id, ProductoDTO dto)
        {
            var response = await _http.PostAsJsonAsync(
                $"api/stock/modificarproducto/{id}",
                dto);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> CrearProducto(ProductoDTO dto)
        {
            var response = await _http.PostAsJsonAsync(
                "api/stock/crearproductos",
                dto);

            return response.IsSuccessStatusCode;
        }

        public async Task<List<ProductoMasVendidoDto>> ProductoMasVendido()
        {
            var response = await _http.GetFromJsonAsync<List<ProductoMasVendidoDto>>("api/dashboard/masvendidos") ?? new();
            return response;
        }
    }
}
