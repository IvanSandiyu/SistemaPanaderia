using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Domain.Entidades
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = [];
        public int TotalRegistros { get; set; }
        public int PaginaActual { get; set; }
    }
}
