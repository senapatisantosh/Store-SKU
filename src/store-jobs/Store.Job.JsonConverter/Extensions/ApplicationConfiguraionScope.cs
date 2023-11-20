namespace Store.Job.JsonConverter.Extensions;

using Store.Job.JsonConverter.Configs;
using Store.Job.JsonConverter.Constants;

public static class ApplicationConfiguraionScope
{
    public static IServiceCollection ConigureApplication(this IServiceCollection services)
    {
        services.AddOptions<KafkaConsumerOptions>().BindConfiguration(JsonConverterContants.KafkaConsumer).ValidateDataAnnotations();
        services.AddOptions<KafkaProducerOptions>().BindConfiguration(JsonConverterContants.KafkaProducer).ValidateDataAnnotations();
        services.AddOptions<SqlServerOptions>().BindConfiguration(JsonConverterContants.SqlServer).ValidateDataAnnotations();
        services.AddOptions<StorageLocationOptions>().BindConfiguration(JsonConverterContants.StorageLocation).ValidateDataAnnotations();
        return services;
    }
}
