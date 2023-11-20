namespace Store.Api.Ingestion.Configs;

public record SqlServerOptions
{
    public required string ConnectionStrings { get; set;}
}
