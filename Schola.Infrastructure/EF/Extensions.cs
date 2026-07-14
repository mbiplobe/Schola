using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Schola.Application.Services;
using Schola.Infrastructure.EF.Contexts;
using Schola.Infrastructure.EF.Options;
using Schola.Infrastructure.EF.Repositories;
using Schola.Infrastructure.EF.Services;


namespace Schola.Infrastructure.EF;

internal static class Extensions
{
    public static IServiceCollection AddSQLDB(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISubjectRepository, SubjectRepository>();
        services.AddScoped<IClassRepository, ClassEntityRepository>();
        services.AddScoped<ISectionRepository, SectionRepository>();
        services.AddScoped<IUserEntityRepository, UserEntityRepository>();
        services.AddScoped<IUserEntityReadService, UserEntityReadService>();

        var options = configuration.GetSection("DataBaseConnectionString").Get<DataBaseOptions>();

        var connectionString = options?.ConnectionString ?? throw new InvalidOperationException("Database connection string is not configured.");
        var serverVersion = ServerVersion.AutoDetect(connectionString);

        services.AddDbContext<ReadDbContext>(ctx =>
            ctx.UseMySql(options.ConnectionString, serverVersion));

        services.AddDbContext<WriteDbContext>(ctx =>
            ctx.UseMySql(options.ConnectionString, serverVersion));

        return services;
    }

}
