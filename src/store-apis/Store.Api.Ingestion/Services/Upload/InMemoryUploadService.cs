namespace Store.Api.Ingestion.Services.Upload;

using Microsoft.Extensions.Options;
using Store.Api.Ingestion.Configs;

public class InMemoryUploadService : IUploadService
{
    private readonly IOptions<UploadDropLocationOptions> _uploadDropLocationOptions;

    public InMemoryUploadService(IOptions<UploadDropLocationOptions> uploadDropLocationOptions) => _uploadDropLocationOptions = uploadDropLocationOptions;

    public async Task UplooadAsync(IFormFile file)
    {
        var dropLocation = _uploadDropLocationOptions.Value.DropLocation!;
        if (!Directory.Exists(dropLocation))
        {
            Directory.CreateDirectory(dropLocation);
        }
        string fileName = $"{file.FileName}-{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}";
        string filePath = Path.Combine(dropLocation, fileName);
        await using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);
    }
}
