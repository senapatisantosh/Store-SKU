namespace Store.Api.Ingestion.Extensions;

using Microsoft.Extensions.Options;
using Store.Api.Ingestion.Configs;
using Store.Api.Ingestion.Managers;
using Store.Api.Ingestion.Services;
using Store.Api.Ingestion.Services.PublishMetaData;
using Store.Api.Ingestion.Services.StoreMetaData;
using Store.Api.Ingestion.Services.Upload;
using Store.Api.Ingestion.ValueObjects;

public static class CoreApplicationScope
{
    public static IServiceCollection ConigureCoreApplicationScope(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var kafkaConfig = serviceProvider.GetRequiredService<IOptions<KafkaProducerOptions>>().Value;
        services.AddScoped<IUploadService, InMemoryUploadService>();
        services.AddScoped<IStoreMetaDataService, StoreMetaDataService>();
        services.AddSingleton(typeof(IKafkaMessageBus<,>), typeof(KafkaMessageBus<,>));
        services.AddScoped<IIngestionCommand, UploadCommand>();
        services.AddScoped<IIngestionCommand, StoreMetaDataCommand>();
        services.AddScoped<IIngestionCommand, PublishMetaDataCommand>();
        services.AddScoped<IIngestionObserver, IngestionCommandExecutor>();
        services.AddScoped<IIngestionManager, IngestionManager>();
        services.ConigureKafkaProducer<string, FilePayloadMetaData>(p =>
        {
            p.Topic = kafkaConfig.Topic;
            p.BootstrapServers = kafkaConfig.BootstrapServers;
        });
        return services;
    }
}
