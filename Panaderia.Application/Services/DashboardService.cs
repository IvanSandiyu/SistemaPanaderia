using Microsoft.EntityFrameworkCore;
using Panaderia.Application.DTOs.Dashboard;
using Panaderia.Application.Interfaces;
using Panaderia.Shared.DTOs.Productos;
using Panaderia.Shared.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IApplicationDbContext _context;
        public DashboardService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DetalleVentaHistorialDto>> VentasPorDia()
        {

            return await _context.DetalleVentas.GroupBy(x => new
            {
                x.ProductoId,
                x.Producto.Nombre
            }).Select(g => new DetalleVentaHistorialDto
            {
                ProductoId = g.Key.ProductoId,
                Producto = g.Key.Nombre,
                Cantidad = g.Sum(x => x.Cantidad),
                PrecioUnitario = g.Average(x => x.PrecioUnitario),
                Subtotal = g.Sum(x => x.Subtotal)
            }).OrderByDescending(x => x.Cantidad).ToListAsync();
        }

        public async Task<List<MetodoPagoDto>> MetodoDePago()
        {
            return await _context.Ventas.GroupBy(x => x.MetodoPago).Select(g => new MetodoPagoDto
            {
                MetodoDePago = g.Key.ToString(),
                CantidadVentas = g.Count()
            }).ToListAsync();
        }

        public Task<DashboardDto> ObtenerDashboard()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductoMasVendidoDto>> ProductosMasVendidos()
        {
            var productosMasVendidos = await _context.DetalleVentas.Include(x => x.Producto).GroupBy(x => new
            {
                x.ProductoId,
                x.Producto.Nombre
            }).Select(g => new ProductoMasVendidoDto
            {
                Nombre = g.Key.Nombre,
                CantidadVendida = g.Sum(x => x.Cantidad),
                TotalFacturado = g.Sum(x => x.Subtotal)
            }).OrderByDescending(x => x.CantidadVendida).Take(10).ToListAsync();

            return productosMasVendidos;
        }

        public async Task<List<ProductoMasVendidoDto>> ProductosMenosVendidos()
        {
            var productosMenosVendidos = await _context.DetalleVentas.Include(x => x.Producto).GroupBy(x => new
            {
                x.ProductoId,
                x.Producto.Nombre
            }).Select(g => new ProductoMasVendidoDto
            {
                Nombre = g.Key.Nombre,
                CantidadVendida = g.Sum(x => x.Cantidad),
                TotalFacturado = g.Sum(x => x.Subtotal)
            }).OrderBy(x => x.CantidadVendida).Take(10).ToListAsync();

            return productosMenosVendidos;
        }

        public async Task<List<VentaDiariaDto>> VentasDiarias()
        {
            var ventasPorDia = await _context.Ventas.GroupBy(x => x.Fecha.Date).Select(g => new VentaDiariaDto
            {
                Fecha = g.Key,
                Total = g.Sum(x => x.Total)
            }).OrderByDescending(x => x.Fecha).ToListAsync();

            return ventasPorDia;
        }

        public async Task<decimal?> Ganancias()
        {
            var hoy = DateTime.Today;

            return await _context.DetalleVentas
                .Where(x => x.Venta.Fecha.Date == hoy)
                .SumAsync(x =>
                    (x.PrecioUnitario - x.CostoUnitario)
                    * x.Cantidad);
        }
    }
}
