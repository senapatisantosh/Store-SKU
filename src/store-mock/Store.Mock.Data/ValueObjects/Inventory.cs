namespace Store.Mock.Data.ValueObjects;

public record Inventory
{
    public required string Category { get; set; }
    public required string Brand { get; set; }
    public required string Model { get; set; }
    public required string Color { get; set; }
    public required string Size { get; set; }
    public required string SKU { get; set; }
    public required string Price { get; set; }
    public required DateTime Timestamp { get; set; }
    public required string ProductDescription { get; set; }
}
