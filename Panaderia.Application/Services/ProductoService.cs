using Microsoft.EntityFrameworkCore;
using Panaderia.Application.DTOs.Producto;
using Panaderia.Application.Interfaces;
using Panaderia.Domain.Entidades.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IApplicationDbContext _context;

        public ProductoService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarAsync(int id, ProductoDTO dto)
        {
            if (dto == null)
                return false;

            var p = await _context.Productos.FindAsync(id);
            if (p is null)
                return false;

            p.Nombre = dto.Nombre;
            p.PrecioCompra = dto.PrecioCompra;
            p.PrecioVenta = dto.PrecioVenta;
            p.StockActual = dto.StockActual;
            p.Activo = dto.Activo;

            await _context.SaveChangesAsync();
            return true;


        }

        public async Task<bool> CrearAsync(Producto dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(dto));
           
            await _context.Productos.AddAsync(dto);
            if (await _context.SaveChangesAsync() > 0)
                return true;
            return false;
        }

        public Task<bool> EliminarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Producto> ObtenerPorIdAsync(int id)
        {
            return await _context.Productos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Producto>> ObtenerTodosAsync()
        {
            List<Producto> productos;
            productos = await _context.Productos.AsNoTracking().ToListAsync();
            return productos;
        }

        public async Task<bool> OcultarProducto(int id)
        {
            var p = await _context.Productos.FindAsync(id);
            if (p is null)
                return false;

            if(p.Activo == true) {
                p.Activo = false;
            }else {
                p.Activo = true;
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
