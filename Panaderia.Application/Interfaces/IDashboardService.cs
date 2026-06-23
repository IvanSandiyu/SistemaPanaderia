using Panaderia.Application.DTOs;
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
    }
}
