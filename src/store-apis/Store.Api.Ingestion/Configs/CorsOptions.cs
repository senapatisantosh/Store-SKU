namespace Store.Api.Ingestion.Configs;

using System.ComponentModel.DataAnnotations;

public record CorsOptions
{
    [Required]
    [ConfigurationKeyName("Name")]
    public required string Name { get; set; }

    [Required]
    [ConfigurationKeyName("Origins")]
    public required List<string> Origins { get; set; }

    [Required]
    [ConfigurationKeyName("Headers")]
    public required List<string> Headers { get; set; }

    [Required]
    [ConfigurationKeyName("Methods")]
    public required List<string> Methods { get; set; }
}
