using Panaderia.Shared.DTOs.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Application.Interfaces
{
    public interface IReporteExcelService
    {
        byte[] GenerarReporteVentas(List<VentaHistorialDto> ventas);
    }
}
