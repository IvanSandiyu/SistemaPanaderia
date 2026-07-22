using Panaderia.Application.Interfaces;
using Panaderia.Domain.Entidades.Productos;
using Panaderia.Shared.DTOs.Productos;
using Panaderia.Shared.DTOs.Ventas;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Infrastructure.Reporting
{
    public class ReportePdfService : IReportePdfService
    {
        public ReportePdfService()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }
        public byte[] GenerarReporteVentas(List<VentaHistorialDto> ventas)
        {

            QuestPDF.Settings.License = LicenseType.Community;

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);

                    page.Header()
                        .Text("REPORTE DE VENTAS")
                        .FontSize(24)
                        .Bold()
                        .AlignCenter();

                    page.Content().Column(col =>
                    {
                        col.Spacing(10);

                        col.Item().Text($"Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm}");

                        col.Item().Text($"Cantidad de ventas: {ventas.Count}");

                        col.Item().LineHorizontal(1);

                        foreach (var venta in ventas) {
                            col.Item().Border(1).Padding(10).Column(item =>
                            {
                                item.Item().Text($"Venta N° {venta.Id}").Bold();

                                item.Item().Text($"Fecha: {venta.Fecha:dd/MM/yyyy}");

                                item.Item().Text($"Método de Pago: {venta.MetodoPago}");

                                item.Item().Text($"Total: ${venta.Total:N2}");
                            });
                        }
                    });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Página ");
                            x.CurrentPageNumber();
                        });
                });
            });

            return document.GeneratePdf();
        }

        public byte[] GenerarReporteProductos(List<ProductoDTO>? productos)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);

                    page.Header()
                        .Text("REPORTE DE PRODUCTOS")
                        .FontSize(24)
                        .Bold()
                        .AlignCenter();

                    page.Content().Column(col =>
                    {
                        col.Spacing(10);

                        col.Item().Text($"Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm}");

                        col.Item().Text($"Cantidad de productos: {productos.Count}");

                        col.Item().LineHorizontal(1);

                        foreach (var producto in productos) {
                            col.Item().Border(1).Padding(10).Column(item =>
                            {
                                item.Item().Text(producto.Nombre).Bold();

                                item.Item().Text($"ID: {producto.Id}");

                                item.Item().Text($"Precio Compra: ${producto.PrecioCompra:N2}");

                                item.Item().Text($"Precio Venta Kg: ${producto.PrecioVenta:N2}");

                                item.Item().Text($"Precio Venta Unidad: ${producto.PrecioVentaUnidad:N2}");

                                item.Item().Text($"Stock: {producto.StockActual}");

                                //item.Item().Text($"Proveedor: {producto.Proveedor?.Nombre ?? "Sin proveedor"}");
                            });
                        }
                    });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Página ");
                            x.CurrentPageNumber();
                        });
                });
            });

            return document.GeneratePdf();
        }
    }


}
