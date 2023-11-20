namespace Store.Job.JsonConverter.Extensions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Store.Job.JsonConverter.Configs;
using Store.Job.JsonConverter.Services.UpdateFileProcessingStatus;

public static class SqlServerDbScope
{
    public static IServiceCollection ConigureSqlServerDb(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var sqlServerOptions = serviceProvider.GetRequiredService<IOptions<SqlServerOptions>>().Value;
        services.AddDbContext<UpdateFileProcessingStatusDbContext>(options => options.UseSqlServer(sqlServerOptions.ConnectionStrings));
        return services;
    }
}
