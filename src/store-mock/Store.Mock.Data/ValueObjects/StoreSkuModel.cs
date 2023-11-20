namespace Store.Mock.Data.ValueObjects;

public record StoreSkuModel
{
    public required string StoreId { get; set; }
    public required string ProductSku { get; set; }
    public required string ProductName { get; set; }
    public required string ProductDescription { get; set; }
    public required string Pricing { get; set; }
    public required DateTime DateTimestamp { get; set; }
}
