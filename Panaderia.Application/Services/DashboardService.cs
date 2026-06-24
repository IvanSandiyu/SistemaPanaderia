using Microsoft.EntityFrameworkCore;
using Panaderia.Application.DTOs;
using Panaderia.Application.Interfaces;
using Panaderia.Domain.Entidades;
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

        public Task<List<GananciaDto>> Ganancias()
        {
            throw new NotImplementedException();
        }

        public async Task<List<MetodoPagoDTO>> MetodoDePago()
        {
            var metodos = await _context.Ventas.Select(x => new MetodoPagoDTO {
                MetodoDePago = x.MetodoPago
            }).ToListAsync();

            return metodos;
        }

        public Task<DashboardDto> ObtenerDashboard()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductoMasVendidoDto>> ProductosMasVendidos()
        {
            var productosMasVendidos = await _context.DetalleVentas.Include(x => x.Producto).GroupBy(x => new {
                    x.ProductoId,
                    x.Producto.Nombre
            }).Select(g => new ProductoMasVendidoDto {
                Nombre = g.Key.Nombre,
                CantidadVendida = g.Sum(x => x.Cantidad),
                TotalFacturado = g.Sum(x => x.Subtotal)
            }).OrderByDescending(x => x.CantidadVendida).Take(10).ToListAsync();

            return productosMasVendidos;
        }

        public async Task<List<ProductoMasVendidoDto>> ProductosMenosVendidos()
        {
            var productosMenosVendidos = await _context.DetalleVentas.Include(x => x.Producto).GroupBy(x => new {
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
            var ventasPorDia = await _context.Ventas.GroupBy(x => x.Fecha.Date).Select(g => new VentaDiariaDto {
                Fecha = g.Key,
                Total = g.Sum(x => x.Total) 
            }).OrderByDescending(x => x.Fecha).ToListAsync();
        
            return ventasPorDia;
        }

        
    }
}
