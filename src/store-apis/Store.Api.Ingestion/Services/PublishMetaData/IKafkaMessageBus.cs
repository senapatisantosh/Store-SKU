namespace Store.Api.Ingestion.Services.PublishMetaData;

public interface IKafkaMessageBus<Tk, Tv>
{
    Task PublishAsync(Tk key, Tv message);
}
