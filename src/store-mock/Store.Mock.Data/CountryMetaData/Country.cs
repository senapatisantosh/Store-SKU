using Newtonsoft.Json;

namespace Store.Mock.Data.CountryMetaData;

public record Country
{
    [JsonProperty("Country name")]
    public required string CountryName { get; set; }

    [JsonProperty("ISO 3166-2")]
    public required string Iso31662 { get; set; }

    [JsonProperty("ISO 3166-3")]
    public required string Iso31663 { get; set; }

    [JsonProperty("Subdivisions")]
    public required Dictionary<string, string> Subdivisions { get; set; }
}
