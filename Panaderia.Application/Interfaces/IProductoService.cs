using Panaderia.Application.DTOs.Producto;
using Panaderia.Domain.Entidades.Productos;
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

        Task<List<Producto>> ObtenerTodosAsync();

        Task<bool> CrearAsync(Producto dto);

        Task<bool> ActualizarAsync(int id,ProductoDTO dto);

        Task<bool> EliminarAsync(int id);

        Task<bool> OcultarProducto(int id);
    }
}
