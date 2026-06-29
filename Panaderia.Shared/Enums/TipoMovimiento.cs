using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Shared.Enums
{
    public enum TipoMovimiento
    {
        Compra = 1,
        Venta = 2,
        AjustePositivo = 3,  // Ej: Se encontró stock que no estaba registrado
        AjusteNegativo = 4   // Ej: Producto vencido o dañado
    }

}
