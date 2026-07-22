
using Panaderia.Application.Interfaces;
using Panaderia.Shared.DTOs.Productos;
using Panaderia.Shared.DTOs.Proveedores;
using Panaderia.Shared.DTOs.Reportes;

namespace Panaderia.WebApi.Endpoints
{
    public class ReporteEndpoint : IEndpointDefinition
    {
        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            //Los que van con filtro deben ser POST
            var repGroup = app.MapGroup("api/reportes")
                .WithOpenApi();

            repGroup.MapPost("/ventas/pdf", ReporteVentasPdf)
                .WithOpenApi();

            repGroup.MapPost("/ventas/excel", ReporteVentasExcel)
                .WithOpenApi();

            repGroup.MapGet("/productos/pdf", ReporteProductosPdf)
                .WithOpenApi();

            repGroup.MapGet("/productos/excel", ReporteProductosExcel)
                .WithOpenApi();

            repGroup.MapGet("/proveedores/pdf", ReporteProveedoresPdf)
                .WithOpenApi();

            repGroup.MapGet("/proveedores/excel", ReporteProveedoresExcel)
                .WithOpenApi();
        }

        public async Task<IResult> ReporteVentasPdf(ReporteFiltroDto filtro,IVentaService ventaService,IReportePdfService pdfService)
        {
            var ventas = await ventaService.HistorialVentas(filtro);
            var archivo = pdfService.GenerarReporteVentas(ventas);

            return Results.File(archivo,"application/pdf","ReporteVentas.pdf");
        }

        public async Task<IResult> ReporteVentasExcel(ReporteFiltroDto filtro, IVentaService ventaService , IReporteExcelService excelService)
        {
            var ventas = await ventaService.HistorialVentas(filtro);

            var archivo = excelService.GenerarReporteVentas(ventas);

            return Results.File(
                archivo,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "ReporteVentas.xlsx");
        }

        public async Task<IResult> ReporteProductosPdf(IProductoService productoService, IReportePdfService pdfService)
        {
            var p = await productoService.ObtenerTodosAsync();
            var productosDto = p.Select(p => new ProductoDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                PrecioCompra = p.PrecioCompra,
                PrecioVenta = p.PrecioVenta,
                PrecioVentaUnidad = p.PrecioVentaUnidad,
                StockActual = p.StockActual ?? 0,
                ProveedorId = p.ProveedorId ?? 0,
            }).ToList();
            var archivo = pdfService.GenerarReporteProductos(productosDto);

            return Results.File(archivo, "application/pdf", "ReporteProductos.pdf");
        }

        public async Task<IResult> ReporteProductosExcel(IProductoService productoService, IReportePdfService pdfService)
        {
            var p = await productoService.ObtenerTodosAsync();
            var productosDto = p.Select(p => new ProductoDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                PrecioCompra = p.PrecioCompra,
                PrecioVenta = p.PrecioVenta,
                PrecioVentaUnidad = p.PrecioVentaUnidad,
                StockActual = p.StockActual ?? 0,
                ProveedorId = p.ProveedorId ?? 0,
            }).ToList();
            var archivo = pdfService.GenerarReporteProductos(productosDto);

            return Results.File(
                archivo,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "ReporteProductos.xlsx");
        }

        public async Task<IResult> ReporteProveedoresPdf(IProveedorService proveedorService, IReportePdfService pdfService)
        {
            var p = await proveedorService.ObtenerTodos();
            var proveedor= p.Select(p => new ProveedorDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Email = p.Email,
                Activo = p.Activo,
                Direccion = p.Direccion,
                Telefono = p.Telefono,
            }).ToList();
            var archivo = pdfService.GenerarReporteProveedores(proveedor);

            return Results.File(archivo, "application/pdf", "ReporteProveedores.pdf");
        }

        public async Task<IResult> ReporteProveedoresExcel(IProveedorService proveedorService, IReportePdfService pdfService)
        {
            var p = await proveedorService.ObtenerTodos();
            var proveedor = p.Select(p => new ProveedorDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Email = p.Email,
                Activo = p.Activo,
                Direccion = p.Direccion,
                Telefono = p.Telefono,
            }).ToList();
            var archivo = pdfService.GenerarReporteProveedores(proveedor);

            return Results.File(
                archivo,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "ReporteProveedores.xlsx");
        }
    }
}
