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
    public class ProductoService : IProductoService
    {
        private readonly IApplicationDbContext _context;

        public ProductoService(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> ActualizarAsync(int id, ProductoDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<int> CrearAsync(ProductoDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductoDTO> ObtenerPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductoDTO>> ObtenerTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
