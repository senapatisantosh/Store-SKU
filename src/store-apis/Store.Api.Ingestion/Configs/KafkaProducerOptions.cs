using System.ComponentModel.DataAnnotations;

namespace Store.Api.Ingestion.Configs;

public record KafkaProducerOptions
{
    [Required]
    [ConfigurationKeyName("Topic")]
    public required string Topic { get; set; }

    [Required]
    [ConfigurationKeyName("BootstrapServers")]
    public required string BootstrapServers { get; set; }
}
