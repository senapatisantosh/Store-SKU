namespace Store.Job.JsonConverter.Extensions;

using Microsoft.Extensions.Options;
using Store.Job.JsonConverter.Configs;
using Store.Job.JsonConverter.Events.Handlers;
using Store.Job.JsonConverter.Services;
using Store.Job.JsonConverter.Services.KafkaMessageBus;
using Store.Job.JsonConverter.Services.UpdateFileProcessingStatus;
using Store.Job.JsonConverter.ValueObjects;

public static class CoreApplicationScope
{
    public static IServiceCollection ConfigureCoreApplicationScope(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var kafkaConsumerConfig = serviceProvider.GetRequiredService<IOptions<KafkaConsumerOptions>>().Value;
        var kafkaProducerConfig = serviceProvider.GetRequiredService<IOptions<KafkaProducerOptions>>().Value;
        services.AddScoped<IUpdateFileProcessingStatus, UpdateFileProcessingStatus>();
        services.AddSingleton(typeof(IKafkaMessageBus<,>), typeof(KafkaMessageBus<,>));
        services.AddScoped<IJsonConverterCommand, UpdateFileProcessingStatusCommand>();
        services.AddScoped<IJsonConverterCommand, PublishJsonDataCommand>();
        services.AddScoped<IJsonConverterObserver, JsonConverterCommandExecuter>();
        services.ConigureKafkaProducer<string, StoreSku>(p =>
        {
            p.Topic = kafkaProducerConfig.Topic;
            p.BootstrapServers = kafkaProducerConfig.BootstrapServers;
        });
        services.ConigureKafkaConsumer<string, FilePayloadMetaData, JsonConverterHandler>(p =>
        {
            p.Topic = kafkaConsumerConfig.Topic;
            p.GroupId = kafkaConsumerConfig.GroupId;
            p.BootstrapServers = kafkaProducerConfig.BootstrapServers;
        });
        return services;
    }
}
