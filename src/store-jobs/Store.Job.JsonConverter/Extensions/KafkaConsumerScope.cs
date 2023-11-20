namespace Store.Job.JsonConverter.Extensions;

using Store.Job.JsonConverter.Services.KafkaMessageBus.Consumer;

public static class KafkaConsumerScope
{
    public static IServiceCollection ConigureKafkaConsumer<Tk, Tv, THandler>(this IServiceCollection services,
            Action<KafkaConsumerConfig<Tk, Tv>> configAction) where THandler : class, IKafkaHandler<Tk, Tv>
    {
        services.AddScoped<IKafkaHandler<Tk, Tv>, THandler>();

        services.AddHostedService<BackGroundKafkaConsumer<Tk, Tv>>();

        services.Configure(configAction);

        return services;
    }
}
