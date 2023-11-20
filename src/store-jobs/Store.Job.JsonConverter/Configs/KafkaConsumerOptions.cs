namespace Store.Job.JsonConverter.Configs;

using System.ComponentModel.DataAnnotations;

public record KafkaConsumerOptions
{
    [Required]
    [ConfigurationKeyName("Topic")]
    public required string Topic { get; set; }

    [Required]
    [ConfigurationKeyName("GroupId")]
    public required string GroupId { get; set; }

    [Required]
    [ConfigurationKeyName("BootstrapServers")]
    public required string BootstrapServers { get; set; }
}
