using Microsoft.EntityFrameworkCore;
using Panaderia.Application.Interfaces;
using Panaderia.Domain.Entidades.Productos;
using Panaderia.Domain.Entidades.Proveedores;
using Panaderia.Shared.DTOs.Productos;
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
            if (dto == null  )
                return false;
            
            var p = await _context.Productos.FindAsync(id);
            if (p is null)
                return false;

            p.Nombre = dto.Nombre;
            p.PrecioCompra = dto.PrecioCompra;
            p.StockActual = dto.StockActual;
            p.Activo = dto.Activo;
            p.ProveedorId = dto.ProveedorId;


            if (dto.PorcentajeGanancia > 0) {
                p.PrecioVenta =
                    dto.PrecioCompra *
                    (1 + dto.PorcentajeGanancia.Value / 100);

                p.PorcentajeGanancia = dto.PorcentajeGanancia;
            } else {
                p.PrecioVenta = dto.PrecioVenta;
                p.PorcentajeGanancia = 0;
            }
            if (dto.PorcentajeGananciaUnidad > 0) {
                p.PrecioVentaUnidad =
                    dto.PrecioCompraUnidad *
                    (1 + dto.PorcentajeGananciaUnidad.Value / 100);

                p.PorcentajeGananciaUnidad = dto.PorcentajeGananciaUnidad;
            } else {
                p.PrecioVentaUnidad = dto.PrecioVentaUnidad;
                p.PorcentajeGananciaUnidad = 0;
            }


            await _context.SaveChangesAsync();
            return true;


        }

        public async Task<bool> CrearAsync(ProductoDTO dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(dto));

            var producto = new Producto {
                Nombre = dto.Nombre,
                StockActual = dto.StockActual,
                Activo = dto.Activo,
                PrecioCompra = dto.PrecioCompra,
                PrecioCompraUnidad = dto.PrecioCompraUnidad,
                ProveedorId = dto.ProveedorId
            };
            if (dto.PorcentajeGanancia > 0) {
                producto.PorcentajeGanancia = dto.PorcentajeGanancia;

                producto.PrecioVenta = dto.PrecioCompra * (1 + dto.PorcentajeGanancia.Value / 100);
            } else {
                producto.PrecioVenta = dto.PrecioVenta;
            }
            if (dto.PorcentajeGananciaUnidad > 0) {
                producto.PorcentajeGananciaUnidad = dto.PorcentajeGananciaUnidad;

                producto.PrecioVentaUnidad = dto.PrecioCompraUnidad * (1 + dto.PorcentajeGananciaUnidad.Value / 100);
            } else {
                producto.PrecioVentaUnidad = dto.PrecioVentaUnidad;
            }


            await _context.Productos.AddAsync(producto);
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

        public async Task<List<Producto>> ObtenerTodosAsync(int? pag)
        {
            var query = _context.Productos.AsQueryable();

            if (pag.HasValue) {
                const int pageSize = 10;

                query = query
                    .Skip((pag.Value - 1) * pageSize)
                    .Take(pageSize);
            }

            return await query.ToListAsync();
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
