using Microsoft.Extensions.DependencyInjection;
using Panaderia.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Infrastructure.Reporting
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddReporting(this IServiceCollection services)
        {
            services.AddScoped<IReportePdfService, ReportePdfService>();
            services.AddScoped<IReporteExcelService, ReporteExcelService>();

            return services;
        }
    }
}
