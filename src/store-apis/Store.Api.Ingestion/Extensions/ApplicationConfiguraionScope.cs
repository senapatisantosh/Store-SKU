using Store.Api.Ingestion.Configs;
using Store.Api.Ingestion.Constants;

namespace Store.Api.Ingestion.Extensions;

public static class ApplicationConfiguraionScope
{
    public static IServiceCollection ConigureApplication(this IServiceCollection services)
    {
        services.AddOptions<CorsOptions>().BindConfiguration(StoreApiIngestionConstants.Cors).ValidateDataAnnotations();
        services.AddOptions<KafkaProducerOptions>().BindConfiguration(StoreApiIngestionConstants.Kafka).ValidateDataAnnotations();
        services.AddOptions<SqlServerOptions>().BindConfiguration(StoreApiIngestionConstants.SqlServer).ValidateDataAnnotations();
        services.AddOptions<UploadDropLocationOptions>().BindConfiguration(StoreApiIngestionConstants.UploadDropLocation).ValidateDataAnnotations();
        return services;
    }
}
