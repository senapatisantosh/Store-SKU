using Store.Api.Ingestion.ValueObjects;

namespace Store.Api.Ingestion.Services;

public interface IIngestionObserver
{
    Task UpdateIngestionAsync(IFormFile file, FilePayloadMetaData fileMetaData);
}

