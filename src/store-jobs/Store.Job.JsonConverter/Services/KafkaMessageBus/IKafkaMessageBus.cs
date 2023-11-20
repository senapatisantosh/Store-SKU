namespace Store.Job.JsonConverter.Services.KafkaMessageBus;

public interface IKafkaMessageBus<Tk, Tv>
{
    Task PublishAsync(Tk key, Tv message);
}
