using Panaderia.Shared.DTOs.Reportes;
using System.Net.Http.Json;

namespace Panaderia.Blazor.Services
{
    public class ReporteService
    {
        private readonly HttpClient _http;

        public ReporteService(HttpClient http)
        {
            _http = http;
        }

        public async Task<byte[]> ExportarProductosPdf()
        {
            var response = await _http.GetAsync("api/reportes/productos/pdf");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsByteArrayAsync();
        }
        public async Task<byte[]> ExportarProductosExcel()
        {
            var response = await _http.GetAsync("api/reportes/productos/excel");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsByteArrayAsync();
        }

        public async Task<byte[]> ExportarVentasPdf(DateTime? desde, DateTime? hasta)
        {
            ReporteFiltroDto filtro = new ReporteFiltroDto
            {
                Desde = desde,
                Hasta = hasta
            };

            var response = await _http.PostAsJsonAsync(
                "api/reportes/ventas/pdf",
                filtro);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsByteArrayAsync();
        }
        public async Task<byte[]> ExportarVentasExcel(DateTime? desde, DateTime? hasta)
        {
            ReporteFiltroDto filtro = new ReporteFiltroDto
            {
                Desde = desde,
                Hasta = hasta
            };

            var response = await _http.PostAsJsonAsync(
                "api/reportes/ventas/excel",
                filtro);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsByteArrayAsync();
        }

        public async Task<byte[]> ExportarProveedoresPdf()
        {
            var response = await _http.GetAsync("api/reportes/proveedores/pdf");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsByteArrayAsync();
        }

        public async Task<byte[]> ExportarProveedoresExcel()
        {
            var response = await _http.GetAsync(
                "api/reportes/proveedores/excel");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsByteArrayAsync();
        }

    }
}
