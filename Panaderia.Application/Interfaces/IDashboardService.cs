using Panaderia.Application.DTOs.Dashboard;
using Panaderia.Application.DTOs.Venta;
using Panaderia.Application.DTOs.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Application.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardDto> ObtenerDashboard();
        Task<List<ProductoMasVendidoDto>> ProductosMasVendidos();
        Task<List<ProductoMasVendidoDto>> ProductosMenosVendidos();

        Task<List<VentaDiariaDto>> VentasDiarias();
        Task<List<MetodoPagoDTO>> MetodoDePago();
        Task<List<GananciaDto>> Ganancias();

    }
}
