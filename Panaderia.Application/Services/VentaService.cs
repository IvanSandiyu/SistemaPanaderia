using Microsoft.EntityFrameworkCore;
using Panaderia.Application.Interfaces;
using Panaderia.Application.Specifications;
using Panaderia.Application.Specifications.Ventas;
using Panaderia.Domain.Entidades.Enums;
using Panaderia.Domain.Entidades.Ventas;
using Panaderia.Shared.DTOs.Reportes;
using Panaderia.Shared.DTOs.Ventas;
using Panaderia.Shared.Enums;
using Panaderia.Shared.Ventas;
using System.ComponentModel.Design;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Panaderia.Application.Services
{
    public class VentaService : IVentaService
    {
        private readonly IApplicationDbContext _context;

        public VentaService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<VentaHistorialDto>> HistorialVentas(DateTime? desde, DateTime? hasta, int? pagina)
        {
            var spec = new HistorialVentasSpecification();

            var query = SpecificationEvaluator<Venta>
                .GetQuery(_context.Ventas.AsQueryable(), spec);

            query = query
                .Include(v => v.Detalles)
                .ThenInclude(d => d.Producto);

            query = AplicarFiltroFechas(query, desde, hasta);

            pagina ??= 1;

            query = query
                .Skip((pagina.Value - 1) * 10)
                .Take(10);

            var ventas = await query.ToListAsync();

            return MapearVentas(ventas);
        }
        public async Task<List<VentaHistorialDto>> HistorialVentas(ReporteFiltroDto filtro)
        {
            var query = _context.Ventas.Include(v => v.Detalles).ThenInclude(d => d.Producto).AsQueryable();

            query = AplicarFiltroFechas(
                query,
                filtro.Desde,
                filtro.Hasta);

            var ventas = await query
                .OrderByDescending(x => x.Fecha)
                .ToListAsync();

            return MapearVentas(ventas);
        }

        public async Task<bool> VentaRealizada(VentaDto dto)
        {
            try {
                var venta = new Venta
                {
                    Fecha = DateTime.Now,
                    Total = 0,
                    MetodoPago = (Panaderia.Domain.Entidades.Enums.MetodoDePago)(int)dto.MetodoPago,
                    Observaciones = dto.Observaciones
                };
                await _context.Ventas.AddAsync(venta);


                foreach (var detalle in dto.Detalles) {
                    var p = await _context.Productos.FirstOrDefaultAsync(x => x.Id == detalle.ProductoID);
                    if (p is null || p.StockActual < detalle.Cantidad) {
                        return false;
                    }
                    p.StockActual -= detalle.Cantidad;
                    var tipoVenta =(Panaderia.Domain.Entidades.Enums.TipoVenta)(int)detalle.TipoVenta;

                    decimal? precioAplicado =
                        tipoVenta == Panaderia.Domain.Entidades.Enums.TipoVenta.Unidad
                            ? p.PrecioVentaUnidad ?? 0
                            : p.PrecioVenta;

                    //Para calcular las ganancias luego
                    decimal costoAplicado = 
                        tipoVenta == Panaderia.Domain.Entidades.Enums.TipoVenta.Unidad 
                        ? p.PrecioCompraUnidad ?? 0 
                        : p.PrecioCompra ?? 0;

                    decimal? subtotal = precioAplicado * detalle.Cantidad;

                    venta.Total += subtotal;


                    venta.Detalles.Add(new DetalleVenta
                    {
                        ProductoId = p.Id,
                        Cantidad = detalle.Cantidad,
                        PrecioUnitario = precioAplicado ?? 0,
                        Subtotal = subtotal ?? 0,
                        CostoUnitario = costoAplicado,
                        //Subtotal = p.PrecioVentaUnidad * detalle.Cantidad ?? 0

                    });
                    var tipoMovimiento = (Panaderia.Domain.Entidades.Enums.TipoMovimiento)(int)detalle.TipoMovimiento;

                    await _context.MovimientosStock.AddAsync(
                        new MovimientoStock
                        {
                            ProductoId = p.Id,
                            Cantidad = detalle.Cantidad,
                            Tipo = tipoMovimiento,
                            Fecha = DateTime.UtcNow
                        });
                }
                
                await _context.SaveChangesAsync();

                return true;

            } catch (Exception ex) {
                return false;
            }
            
        }

        //Solamente mapeo para no repetir codigo con los metodos de Historial
        private List<VentaHistorialDto> MapearVentas(List<Venta> ventas)
        {
            return ventas.Select(v => new VentaHistorialDto
            {
                Id = v.Id,
                Fecha = v.Fecha,
                Total = v.Total,
                MetodoPago = (Panaderia.Shared.Enums.MetodoDePago)(int)v.MetodoPago,

                Detalles = v.Detalles.Select(d => new DetalleVentaHistorialDto
                {
                    ProductoId = d.ProductoId,
                    Cantidad = d.Cantidad,
                    Producto = d.Producto.Nombre,
                    PrecioUnitario = d.PrecioUnitario,
                    Subtotal = d.Subtotal
                }).ToList()

            }).ToList();
        }
        //Filtrado de fehcas, lo mismo para no repetir 
        private IQueryable<Venta> AplicarFiltroFechas(IQueryable<Venta> query,DateTime? desde,DateTime? hasta)
        {
            if (desde.HasValue)
                query = query.Where(x => x.Fecha >= desde.Value);

            if (hasta.HasValue)
                query = query.Where(x => x.Fecha <= hasta.Value);

            return query;
        }

        public async Task<List<VentaHistorialDto>> ListaVentas(int? pag = null)
        {
            var query = _context.Ventas
                .Include(v => v.Detalles)
                .ThenInclude(d => d.Producto)
                .AsQueryable();

            if (pag.HasValue) {
                const int pageSize = 10;

                query = query
                    .Skip((pag.Value - 1) * pageSize)
                    .Take(pageSize);
            }

            var ventas = await query.ToListAsync();
            return MapearVentas(ventas);
        }
    }
}
