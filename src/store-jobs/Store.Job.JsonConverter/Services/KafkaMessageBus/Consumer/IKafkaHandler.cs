namespace Store.Job.JsonConverter.Services.KafkaMessageBus.Consumer;

public interface IKafkaHandler<Tk, Tv>
{
    Task HandleAsync(Tk key, Tv value);
}
