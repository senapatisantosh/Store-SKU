namespace Store.Job.JsonConverter.Services.KafkaMessageBus.Consumer;

using Confluent.Kafka;

public class KafkaConsumerConfig<Tk, Tv> : ConsumerConfig
{
    public string? Topic { get; set; }
    public new string? GroupId { get; set; }
    public KafkaConsumerConfig()
    {
        AutoOffsetReset = Confluent.Kafka.AutoOffsetReset.Earliest;
        EnableAutoOffsetStore = false;
    }
}
