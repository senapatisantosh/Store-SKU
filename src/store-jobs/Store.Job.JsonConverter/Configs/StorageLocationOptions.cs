namespace Store.Job.JsonConverter.Configs;

using System.ComponentModel.DataAnnotations;

public record StorageLocationOptions
{
    [Required]
    [ConfigurationKeyName("CsvStorage")]
    public required string CsvStorage { get; set; }
}
