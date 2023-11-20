namespace Store.Api.Ingestion.Services.Upload;

using Store.Api.Ingestion.ValueObjects;

public class UploadCommand : IIngestionCommand, IIngestionCommandOrder
{
    private readonly IUploadService _uploadService;
    public int Order => 1;

    public UploadCommand(IUploadService uploadService)
    {
        _uploadService = uploadService;
    }

    public async Task ExecuteIngestionAync(IFormFile file, FilePayloadMetaData fileMetaData)
    {
        await _uploadService.UplooadAsync(file);
    }
}
