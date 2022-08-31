namespace TpDojo.Dal.Extensions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TpDojo.Dal.Abstractions;
using TpDojo.Dal.AccessLayer;

public static class DalExtensions
{
    public static void AddDalServices(this IServiceCollection services)
    {
        var provider = services.BuildServiceProvider();
        var configuration = provider.GetRequiredService<IConfiguration>();

        services.AddTransient<IArmeAccessLayer, ArmeAccessLayer>();
        services.AddTransient<ISamouraiAccessLayer, SamouraiAccessLayer>();
        services.AddTransient<IArtMartialAccessLayer, ArtMartialAccessLayer>();


        services.AddDbContext<TpDojoContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("TpDojoContext") 
                    ?? throw new InvalidOperationException("Connection string 'TpDojoContext' not found.")));

    }
}
