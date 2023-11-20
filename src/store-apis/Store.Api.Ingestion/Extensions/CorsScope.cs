namespace Store.Api.Ingestion.Extensions;

using Microsoft.Extensions.Options;
using Store.Api.Ingestion.Configs;

public static class CorsScope
{
    public static IServiceCollection ConigureCors(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var corsOptions = serviceProvider.GetRequiredService<IOptions<CorsOptions>>().Value;
        services.AddCors(options =>
        {
            options.AddPolicy(corsOptions.Name, builder =>
            {
                builder.WithOrigins(string.Join(',', corsOptions.Origins))
                       .AllowAnyHeader()
                       .WithMethods(string.Join(',', corsOptions.Methods));
            });
        });
        return services;
    }
}
