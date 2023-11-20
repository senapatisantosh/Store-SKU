namespace Store.Api.Ingestion.Services.Upload;

public interface IUploadService
{
    Task UplooadAsync(IFormFile file);
}
