using Microsoft.EntityFrameworkCore;
using Panaderia.Application.DTOs;
using Panaderia.Application.Interfaces;
using Panaderia.Domain.Entidades;
using Panaderia.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Application.Services
{
    public class VentaService : IVentaService
    {
        private readonly IApplicationDbContext _context;

        public VentaService(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> VentaRealizada(VentaDto dto)
        {
            try {
                var venta = new Venta
                {
                    Fecha = DateTime.UtcNow,
                    Total = 0,
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
