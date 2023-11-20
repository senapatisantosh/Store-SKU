namespace Store.Api.Ingestion.Services.PublishMetaData.Producer;

using Confluent.Kafka;

public class KafkaProducerConfig<Tk, Tv> : ProducerConfig
{
    public required string Topic { get; set; }
}
