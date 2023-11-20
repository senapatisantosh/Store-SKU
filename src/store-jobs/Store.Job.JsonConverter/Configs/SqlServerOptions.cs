namespace Store.Job.JsonConverter.Configs;

public record SqlServerOptions
{
    public required string ConnectionStrings { get; set; }
}
