using Panaderia.Domain.Entidades.Proveedores;
using Panaderia.Shared.DTOs.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Application.Interfaces
{
    public interface IProveedorService
    {
        Task<List<Proveedor>> ObtenerTodos();
        Task<bool> CrearProveedor(ProveedorDTO dto);
        Task<bool> EditarProveedor(int id,ProveedorDTO dto);
        Task<bool> EstadoProveedor(int id);
        Task<ProveedorDTO> ObtenerPorId(int id);
    }
}
