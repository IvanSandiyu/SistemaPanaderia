using ClosedXML.Excel;
using Panaderia.Application.Interfaces;
using Panaderia.Shared.DTOs.Productos;
using Panaderia.Shared.DTOs.Proveedores;
using Panaderia.Shared.DTOs.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Infrastructure.Reporting
{
    public class ReporteExcelService : IReporteExcelService
    {
        public byte[] GenerarReporteVentas(List<VentaHistorialDto> ventas)
        {
            using var workbook = new XLWorkbook();

            var hoja = workbook.Worksheets.Add("Ventas");

            hoja.Cell(1, 1).Value = "Fecha";
            hoja.Cell(1, 2).Value = "Hora";
            hoja.Cell(1, 3).Value = "Método de Pago";
            hoja.Cell(1, 4).Value = "Total";

            int fila = 2;

            foreach (var venta in ventas) {
                hoja.Cell(fila, 1).Value = venta.Fecha.ToShortDateString();
                hoja.Cell(fila, 2).Value = venta.Fecha.ToShortTimeString();
                hoja.Cell(fila, 3).Value = venta.MetodoPago.ToString();
                hoja.Cell(fila, 4).Value = venta.Total ?? 0;

                fila++;
            }

            hoja.Columns().AdjustToContents();

            using var stream = new MemoryStream();

            workbook.SaveAs(stream);

            return stream.ToArray();
        }

        public byte[] GenerarReporteProductos(List<ProductoDTO> productos)
        {
            using var workbook = new XLWorkbook();

            var hoja = workbook.Worksheets.Add("Productos");

            hoja.Cell(1, 1).Value = "ID";
            hoja.Cell(1, 2).Value = "Nombre";
            hoja.Cell(1, 3).Value = "Precio Compra";
            hoja.Cell(1, 4).Value = "Precio Venta Kg";
            hoja.Cell(1, 5).Value = "Precio Venta Unidad";
            hoja.Cell(1, 6).Value = "Stock";

            int fila = 2;

            foreach (var producto in productos) {
                hoja.Cell(fila, 1).Value = producto.Id;
                hoja.Cell(fila, 2).Value = producto.Nombre;
                hoja.Cell(fila, 3).Value = producto.PrecioCompra ?? 0;
                hoja.Cell(fila, 4).Value = producto.PrecioVenta ?? 0;
                hoja.Cell(fila, 5).Value = producto.PrecioVentaUnidad ?? 0;
                hoja.Cell(fila, 6).Value = producto.StockActual;

                fila++;
            }

            hoja.Columns().AdjustToContents();

            using var stream = new MemoryStream();

            workbook.SaveAs(stream);

            return stream.ToArray();
        }

        public byte[] GenerarReporteProveedores(List<ProveedorDTO> proveedores)
        {
            using var workbook = new XLWorkbook();

            var hoja = workbook.Worksheets.Add("Proveedores");

            hoja.Cell(1, 1).Value = "ID";
            hoja.Cell(1, 2).Value = "Nombre";
            hoja.Cell(1, 3).Value = "CUIT";
            hoja.Cell(1, 4).Value = "Teléfono";
            hoja.Cell(1, 5).Value = "Email";
            hoja.Cell(1, 6).Value = "Dirección";
            hoja.Cell(1, 7).Value = "Activo";

            int fila = 2;

            foreach (var proveedor in proveedores) {
                hoja.Cell(fila, 1).Value = proveedor.Id;
                hoja.Cell(fila, 2).Value = proveedor.Nombre;
                hoja.Cell(fila, 3).Value = proveedor.Cuit;
                hoja.Cell(fila, 4).Value = proveedor.Telefono;
                hoja.Cell(fila, 5).Value = proveedor.Email;
                hoja.Cell(fila, 6).Value = proveedor.Direccion;
                hoja.Cell(fila, 7).Value = proveedor.Activo ? "Activo" : "Inactivo";

                fila++;
            }

            hoja.Columns().AdjustToContents();

            using var stream = new MemoryStream();

            workbook.SaveAs(stream);

            return stream.ToArray();
        }
    }
}
