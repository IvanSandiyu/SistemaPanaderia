using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Application.DTOs.Ventas
{
    public record DetalleVentaDTO 
    {
        public int ProductoID { get; set; }
        public int Cantidad {  get; set; }
    }
    
        
    
}
