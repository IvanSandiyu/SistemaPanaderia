using ClosedXML.Excel;
using Panaderia.Application.Interfaces;
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
    }
}
