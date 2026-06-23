using Microsoft.EntityFrameworkCore;
using Panaderia.Application.DTOs;
using Panaderia.Application.Interfaces;
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

       
    }
}
