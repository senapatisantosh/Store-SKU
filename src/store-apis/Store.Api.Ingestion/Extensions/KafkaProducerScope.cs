namespace Store.Api.Ingestion.Extensions;

using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Store.Api.Ingestion.Services.PublishMetaData;
using Store.Api.Ingestion.Services.PublishMetaData.Producer;

public static class KafkaProducerScope
{
    public static IServiceCollection ConigureKafkaProducer<Tk, Tv>(this IServiceCollection services,
            Action<KafkaProducerConfig<Tk, Tv>> configAction)
    {
        services.AddConfluentKafkaProducer<Tk, Tv>();
        services.AddSingleton<KafkaProducer<Tk, Tv>>();
        services.Configure(configAction);
        return services;
    }

    private static IServiceCollection AddConfluentKafkaProducer<Tk, Tv>(this IServiceCollection services)
    {
        services.AddSingleton(
            sp =>
            {
                var config = sp.GetRequiredService<IOptions<KafkaProducerConfig<Tk, Tv>>>();

                var builder = new ProducerBuilder<Tk, Tv>(config.Value).SetValueSerializer(new KafkaSerializer<Tv>());

                return builder.Build();
            });

        return services;
    }
}
