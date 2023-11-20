namespace Store.Job.JsonConverter.ValueObjects;

public class FilePayloadMetaData
{
    public int Id { get; set; }
    public string? UniqueStoreId { get; set; }
    public string? FileName { get; set; }
    public string? StoreId { get; set; }
    public double FileSizeInKB { get; set; }
    public DateTime TimeStamp { get; set; }
    public string? Status { get; set; }
}
