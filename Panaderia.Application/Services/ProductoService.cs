using Microsoft.EntityFrameworkCore;
using Panaderia.Application.DTOs;
using Panaderia.Application.Interfaces;
using Panaderia.Domain.Entidades;
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

        public Task<bool> ActualizarAsync(int id, Producto dto)
        {
            throw new NotImplementedException();
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

        public Task<Producto> ObtenerPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Producto>> ObtenerTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
