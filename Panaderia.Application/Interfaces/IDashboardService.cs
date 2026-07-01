using Panaderia.Application.DTOs.Dashboard;
using Panaderia.Shared.DTOs.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panaderia.Shared.Ventas;

namespace Panaderia.Application.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardDto> ObtenerDashboard();
        Task<List<ProductoMasVendidoDto>> ProductosMasVendidos();
        Task<List<DetalleVentaHistorialDto>> VentasPorDia();
        Task<List<ProductoMasVendidoDto>> ProductosMenosVendidos();

        Task<List<VentaDiariaDto>> VentasDiarias();
        Task<List<MetodoPagoDto>> MetodoDePago();
        Task<decimal?> Ganancias();

    }
}
