namespace Store.Job.JsonConverter.Services.KafkaMessageBus.Producer;

using Confluent.Kafka;

public class KafkaProducerConfig<Tk, Tv> : ProducerConfig
{
    public required string Topic { get; set; }
}
