using Schola.Application.Services;
using Schola.Domain.Repositories;
using Schola.Infrastructure.EF.Contexts;
using Schola.Infrastructure.EF.Options;
using Schola.Infrastructure.EF.Repositories;
using Schola.Infrastructure.EF.Services;
using Schola.Shared.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Schola.Infrastructure.EF;

internal static class Extensions
{
    public static IServiceCollection AddSQLDB(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISampleEntityRepository, SampleEntityRepository>();
        services.AddScoped<ISampleEntityReadService, SampleEntityReadService>();

        var options = configuration.GetOptions<DataBaseOptions>("DataBaseConnectionString");

        var serverVersion = ServerVersion.AutoDetect(options.ConnectionString);

        services.AddDbContext<ReadDbContext>(ctx =>
            ctx.UseMySql(options.ConnectionString, serverVersion));

        services.AddDbContext<WriteDbContext>(ctx =>
            ctx.UseMySql(options.ConnectionString, serverVersion));

        return services;
    }

}
