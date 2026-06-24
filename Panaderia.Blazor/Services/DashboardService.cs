using Panaderia.Blazor.Models;
using System.Net.Http.Json;

namespace Panaderia.Blazor.Services
{
    public class DashboardService
    {
        private readonly HttpClient _http;

        public DashboardService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<VentaDiariaDto>> VentasPorDia()
        {
            var response = await _http.GetFromJsonAsync<List<VentaDiariaDto>>($"api/dashboard/ventapordia") ?? new();
            return response;
        }

        public async Task<List<MetodoPagoDto>> MetodoPago()
        {
            var response = await _http.GetFromJsonAsync<List<MetodoPagoDto>>("api/dashboard/metodos-pagos") ?? new();
            return response;
        }
    }
}
