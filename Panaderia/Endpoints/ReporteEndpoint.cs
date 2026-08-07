
using Panaderia.Application.Interfaces;
using Panaderia.Shared.DTOs.Productos;
using Panaderia.Shared.DTOs.Proveedores;
using Panaderia.Shared.DTOs.Reportes;

namespace Panaderia.WebApi.Endpoints
{
    public class ReporteEndpoint : IEndpointDefinition
    {
        private const string ContentTypeExcel = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

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

        public async Task<IResult> ReporteVentasPdf(ReporteFiltroDto filtro, IVentaService ventaService, IReportePdfService pdfService)
        {
            var ventas = await ventaService.HistorialVentas(filtro);
            var archivo = pdfService.GenerarReporteVentas(ventas);

            return Results.File(archivo, "application/pdf", "ReporteVentas.pdf");
        }

        public async Task<IResult> ReporteVentasExcel(ReporteFiltroDto filtro, IVentaService ventaService, IReporteExcelService excelService)
        {
            var ventas = await ventaService.HistorialVentas(filtro);

            var archivo = excelService.GenerarReporteVentas(ventas);

            return Results.File(
                archivo,
                ContentTypeExcel,
                "ReporteVentas.xlsx");
        }

        public async Task<IResult> ReporteProductosPdf(IProductoService productoService, IReportePdfService pdfService)
        {
            var productos = MapearProductos(await productoService.ObtenerTodosAsync());
            var archivo = pdfService.GenerarReporteProductos(productos);

            return Results.File(archivo, "application/pdf", "ReporteProductos.pdf");
        }

        public async Task<IResult> ReporteProductosExcel(IProductoService productoService, IReporteExcelService excelService)
        {
            var productos = MapearProductos(await productoService.ObtenerTodosAsync());
            var archivo = excelService.GenerarReporteProductos(productos);

            return Results.File(
                archivo,
                ContentTypeExcel,
                "ReporteProductos.xlsx");
        }

        public async Task<IResult> ReporteProveedoresPdf(IProveedorService proveedorService, IReportePdfService pdfService)
        {
            var proveedores = MapearProveedores(await proveedorService.ObtenerTodos());
            var archivo = pdfService.GenerarReporteProveedores(proveedores);

            return Results.File(archivo, "application/pdf", "ReporteProveedores.pdf");
        }

        public async Task<IResult> ReporteProveedoresExcel(IProveedorService proveedorService, IReporteExcelService excelService)
        {
            var proveedores = MapearProveedores(await proveedorService.ObtenerTodos());
            var archivo = excelService.GenerarReporteProveedores(proveedores);

            return Results.File(
                archivo,
                ContentTypeExcel,
                "ReporteProveedores.xlsx");
        }

        private List<ProductoDTO> MapearProductos(IEnumerable<Panaderia.Domain.Entidades.Productos.Producto> productos)
        {
            return productos.Select(p => new ProductoDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                PrecioCompra = p.PrecioCompra,
                PrecioVenta = p.PrecioVenta,
                PrecioVentaUnidad = p.PrecioVentaUnidad,
                StockActual = p.StockActual ?? 0,
                ProveedorId = p.ProveedorId,
            }).ToList();
        }

        private List<ProveedorDTO> MapearProveedores(IEnumerable<Panaderia.Domain.Entidades.Proveedores.Proveedor> proveedores)
        {
            return proveedores.Select(p => new ProveedorDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Email = p.Email,
                Activo = p.Activo,
                Direccion = p.Direccion,
                Telefono = p.Telefono,
            }).ToList();
        }
    }
}
