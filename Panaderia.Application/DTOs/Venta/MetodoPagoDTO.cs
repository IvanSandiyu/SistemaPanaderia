using Panaderia.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Application.DTOs.Venta
{
    public class MetodoPagoDTO
    {
        public string MetodoDePago {  get; set; }
        public int CantidadVentas { get; set; }
    }
}
