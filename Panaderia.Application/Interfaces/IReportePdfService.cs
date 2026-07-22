using Panaderia.Shared.DTOs.Productos;
using Panaderia.Shared.DTOs.Proveedores;
using Panaderia.Shared.DTOs.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Application.Interfaces
{
    public interface IReportePdfService
    {
        byte[] GenerarReporteVentas(List<VentaHistorialDto> ventas);
        byte[] GenerarReporteProductos(List<ProductoDTO>? productos);
        byte[] GenerarReporteProveedores(List<ProveedorDTO>? proveedores);
    }
}
