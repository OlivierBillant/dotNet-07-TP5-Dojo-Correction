namespace TpDojo.Business.Extensions;

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpDojo.Dal.Abstractions;
using TpDojo.Dal.Extensions;

public static class BusinessExtensions
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddTransient<ArmeService>();
        services.AddTransient<SamouraiService>();
        services.AddDalServices();
    }
}
