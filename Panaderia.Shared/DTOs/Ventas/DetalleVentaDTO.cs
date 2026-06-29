using Panaderia.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Shared.DTOs.Ventas
{
    public record DetalleVentaDTO 
    {
        public int ProductoID { get; set; }
        public decimal? Cantidad {  get; set; }
        public decimal PrecioUnitario { get; set; }

        public TipoVenta TipoVenta { get; set; }
        public decimal? Subtotal {  get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
    }
    
        
    
}
