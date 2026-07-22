using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Shared.DTOs.Reportes
{
    public class ReporteFiltroDto
    {
        public DateTime? Desde { get; set; }

        public DateTime? Hasta { get; set; }

        //public string? Buscar { get; set; }
    }
}
