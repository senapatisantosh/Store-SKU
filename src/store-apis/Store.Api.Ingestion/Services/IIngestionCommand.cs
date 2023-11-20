namespace Store.Api.Ingestion.Services;

using Store.Api.Ingestion.ValueObjects;

public interface IIngestionCommand
{
    Task ExecuteIngestionAync(IFormFile file, FilePayloadMetaData fileMetaData);
}
