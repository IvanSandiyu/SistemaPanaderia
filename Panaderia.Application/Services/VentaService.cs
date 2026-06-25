using Microsoft.EntityFrameworkCore;
using Panaderia.Application.DTOs.Ventas;
using Panaderia.Application.Interfaces;
using Panaderia.Application.Specifications;
using Panaderia.Application.Specifications.Ventas;
using Panaderia.Domain.Entidades;
using Panaderia.Domain.Entidades.Ventas;
using Panaderia.Domain.Enums;
using System.ComponentModel.Design;
using System.Linq;

namespace Panaderia.Application.Services
{
    public class VentaService : IVentaService
    {
        private readonly IApplicationDbContext _context;

        public VentaService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<VentaHistorialDTO>> HistorialVentas(DateTime? desde, DateTime? hasta, int? pagina)
        {
            const int pageSize = 10;
            var spec = new HistorialVentasSpecification();
            var query = SpecificationEvaluator<Venta>.GetQuery(_context.Ventas.AsQueryable(), spec);
            query = query.Include(v => v.Detalles).ThenInclude(d => d.Producto);
            
            if (desde.HasValue) query = query.Where(x => x.Fecha >= desde.Value);
            if (hasta.HasValue) query = query.Where(x => x.Fecha <= hasta.Value);
            
            if (!pagina.HasValue) pagina = 1;
            query = query.Skip((pagina.Value - 1) * 10) .Take(10);
            var ventas = await query.ToListAsync();
            //var ventas = await _context.Ventas.Include(x => x.Detalles).ThenInclude(x => x.Producto).ToListAsync();
            //var ventas = await query.ToListAsync();

            //var ventas = await query.ToListAsync();
            return ventas.Select(v => new VentaHistorialDTO
                {
                    Id = v.Id,
                    Fecha = v.Fecha,
                    Total = v.Total,

                    Detalles = v.Detalles.Select(d => new DetalleVentaHistorialDTO
                    {
                        ProductoId = d.ProductoId,
                        Cantidad = d.Cantidad,
                        Producto = d.Producto.Nombre,
                        PrecioUnitario = d.PrecioUnitario,
                        Subtotal = d.Subtotal,
                        
                    }).ToList()
                }).ToList();
        }

        public async Task<bool> VentaRealizada(VentaDto dto)
        {
            try {
                var venta = new Venta
                {
                    Fecha = DateTime.Now,
                    Total = 0,
                    MetodoPago = dto.MetodoPago,
                    Observaciones = dto.Observaciones
                };

                foreach (var detalle in dto.Detalles) {
                    var p = await _context.Productos.FirstOrDefaultAsync(x => x.Id == detalle.ProductoID);
                    if (p is null || p.StockActual < detalle.Cantidad) {
                        return false;
                    }
                    p.StockActual -= detalle.Cantidad;
                    venta.Total += p.PrecioVenta * detalle.Cantidad;

                    venta.Detalles.Add(new DetalleVenta
                    {
                        ProductoId = p.Id,
                        Cantidad = detalle.Cantidad,
                        PrecioUnitario = p.PrecioVenta,
                        Subtotal = p.PrecioVenta * detalle.Cantidad
                        
                    });
                    
                    await _context.Ventas.AddAsync(venta);
                    //await _context.DetalleVentas(venta.Detalles);

                    await _context.MovimientosStock.AddAsync(
                        new MovimientoStock
                        {
                            ProductoId = p.Id,
                            Cantidad = detalle.Cantidad,
                            Tipo = TipoMovimiento.Venta,
                            Fecha = DateTime.UtcNow
                        });
                }
                
                await _context.SaveChangesAsync();

                return true;

            } catch (Exception ex) {
                return false;
            }
            
        }
    }
}
