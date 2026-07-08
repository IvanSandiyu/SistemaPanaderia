using Microsoft.EntityFrameworkCore;
using Panaderia.Application.Interfaces;
using Panaderia.Domain.Entidades.Proveedores;
using Panaderia.Shared.DTOs.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Application.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly IApplicationDbContext _context;
        public ProveedorService(IApplicationDbContext context)
        {
            _context = context;
        }
        public bool CrearProveedor(ProveedorDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool DesactivarProveedor()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProveedorDTO>> EditarProveedor(ProveedorDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Proveedor>> ObtenerTodos()
        {
            List<Proveedor> lista;
            lista = await _context.Proveedores.AsNoTracking().ToListAsync();
            return lista;
        }
    }
}
