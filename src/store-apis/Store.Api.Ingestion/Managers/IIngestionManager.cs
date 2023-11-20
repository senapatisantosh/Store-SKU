namespace Store.Api.Ingestion.Managers;

public interface IIngestionManager
{
    Task HandleIngestionAsync(IFormFile file);
    Task HandleMultipleIngestionAsync(IFormFileCollection files);
}

