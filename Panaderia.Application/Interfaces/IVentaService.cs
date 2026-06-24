using Panaderia.Application.DTOs.Ventas;
using Panaderia.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Application.Interfaces
{
    public interface IVentaService
    {
        public Task<bool> VentaRealizada(VentaDto productos);
        public Task<List<VentaHistorialDTO>> HistorialVentas(DateTime? desde, DateTime? hasta, int? pagina);
    }
}
