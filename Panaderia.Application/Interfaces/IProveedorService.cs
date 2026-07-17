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
        Task<List<ProveedorDTO>> EditarProveedor(ProveedorDTO dto);
        bool DesactivarProveedor();
    }
}
