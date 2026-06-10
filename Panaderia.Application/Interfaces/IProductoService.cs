using Panaderia.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Application.Interfaces
{
    public interface IProductoService
    {
        Task<ProductoDTO> ObtenerPorIdAsync(int id);

        Task<List<ProductoDTO>> ObtenerTodosAsync();

        Task<int> CrearAsync(ProductoDTO dto);

        Task<bool> ActualizarAsync(int id,ProductoDTO dto);

        Task<bool> EliminarAsync(int id);
    }
}
