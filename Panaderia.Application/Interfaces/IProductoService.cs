using Panaderia.Domain.Entidades.Productos;
using Panaderia.Shared.DTOs.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Application.Interfaces
{
    public interface IProductoService
    {
        Task<Producto> ObtenerPorIdAsync(int id);

        Task<List<Producto>> ObtenerTodosAsync(int? pag=null);

        Task<bool> CrearAsync(ProductoDTO dto);

        Task<bool> ActualizarAsync(int id,ProductoDTO dto);

        Task<bool> EliminarAsync(int id);

        Task<bool> OcultarProducto(int id);
    }
}
