using Panaderia.Domain.Entidades;
using Panaderia.Shared.DTOs.Reportes;
using Panaderia.Shared.DTOs.Ventas;
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
        public Task<List<VentaHistorialDto>> HistorialVentas(DateTime? desde, DateTime? hasta, int? pagina);
        public Task<List<VentaHistorialDto>> HistorialVentas(ReporteFiltroDto filtro);
        public Task<List<VentaHistorialDto>> ListaVentas(int? pag = null);
    }
}
