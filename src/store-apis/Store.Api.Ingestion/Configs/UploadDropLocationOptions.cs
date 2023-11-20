namespace Store.Api.Ingestion.Configs;

using System.ComponentModel.DataAnnotations;

public record UploadDropLocationOptions
{
    [Required]
    [ConfigurationKeyName("DropLocation")]
    public string? DropLocation { get; set;}
}
