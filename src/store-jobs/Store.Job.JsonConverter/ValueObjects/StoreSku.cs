namespace Store.Job.JsonConverter.ValueObjects;

public class StoreSku
{
    public string? StoreId { get; set; }
    public string? ProductSku { get; set; }
    public string? ProductName { get; set; }
    public string? ProductDescription { get; set; }
    public string? Pricing { get; set; }
    public DateTime DateTimestamp { get; set; }
}
