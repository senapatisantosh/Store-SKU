namespace Store.Api.Ingestion.Extensions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Store.Api.Ingestion.Configs;
using Store.Api.Ingestion.Services.StoreMetaData;

public static class SqlServerDbScope
{
    public static IServiceCollection ConigureSqlServerDb(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var sqlServerOptions = serviceProvider.GetRequiredService<IOptions<SqlServerOptions>>().Value;
        services.AddDbContext<StoreMetaDataDbContext>(options => options.UseSqlServer(sqlServerOptions.ConnectionStrings), ServiceLifetime.Scoped);
        return services;
    }
}
