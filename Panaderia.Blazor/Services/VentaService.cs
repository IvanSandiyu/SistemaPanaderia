using Panaderia.Blazor.Models;
using System.Net.Http.Json;

namespace Panaderia.Blazor.Services
{
    public class VentaService
    {
        private readonly HttpClient _http;

        public VentaService(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<VentaHistorialDto>> HistorialVentas(int pagina)
        {
            var response = await _http.GetFromJsonAsync<List<VentaHistorialDto>>($"api/venta/historialventas/{pagina}") ?? new();
            return response;    
        }

        public async Task<bool> RealizarVenta(VentaDto dto)
        {
            var response = await _http.PostAsJsonAsync("api/venta/generarventa", dto);
            return response.IsSuccessStatusCode;
        }
    }
}
