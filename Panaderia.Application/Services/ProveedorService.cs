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
        public async Task<bool> CrearProveedor(ProveedorDTO dto)
        {
            if(dto is null)
                throw new ArgumentNullException(nameof(dto));

            var proveedor = new Proveedor
            {
                Nombre = dto.Nombre,
                Cuit = dto.Cuit,
                Telefono = dto.Telefono,
                Email = dto.Email,
                Direccion = dto.Direccion,
                Activo = dto.Activo
            };

            await _context.Proveedores.AddAsync(proveedor);
            if (await _context.SaveChangesAsync() > 0)
                return true;
            return false;
        }

        public async Task<bool> EstadoProveedor(int id)
        {
            var p = await _context.Proveedores.FindAsync(id);
            if (p == null)
                return false;

            if (p.Activo is true) {
                p.Activo = false;
            }else {
                p.Activo = true;
                
            }
            await _context.SaveChangesAsync();
            return true;


        }

        public async Task<bool> EditarProveedor(int id,ProveedorDTO dto)
        {
            if(dto is null) 
                return false;

            var p = await _context.Proveedores.FindAsync(id);
            if(p is null)
                return false;

            p.Nombre = dto.Nombre;
            p.Cuit = dto.Cuit;
            p.Telefono = dto.Telefono;
            p.Email = dto.Email;
            p.Direccion = dto.Direccion;
            p.Activo = dto.Activo;
            
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Proveedor>> ObtenerTodos()
        {
            List<Proveedor> lista;
            lista = await _context.Proveedores.AsNoTracking().ToListAsync();
            return lista;
        }

        public async Task<ProveedorDTO> ObtenerPorId(int id)
        {
            var p = await _context.Proveedores.FindAsync(id);
            if (p is null)
                return null;

            return new ProveedorDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Cuit = p.Cuit,
                Telefono = p.Telefono,
                Email = p.Email,
                Direccion = p.Direccion,
                Activo = p.Activo
            };
        }
    }
}
