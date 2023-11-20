namespace Store.Api.Ingestion.Managers;

using Store.Api.Ingestion.Services;
using Store.Api.Ingestion.Utils;

public class IngestionManager : IIngestionManager
{
    private readonly IIngestionObserver _ingestionObserver;
    public IngestionManager(IIngestionObserver ingestionObserver)
    {
        _ingestionObserver = ingestionObserver;
    }

    public async Task HandleIngestionAsync(IFormFile file)
    {
        var fileMetaData = Helper.GetFileMetaDataInfo(file.FileName, file.Length);
        await _ingestionObserver.UpdateIngestionAsync(file, fileMetaData);
    }

    public async Task HandleMultipleIngestionAsync(IFormFileCollection files)
    {
        foreach (var file in files)
        {
            var fileMetaData = Helper.GetFileMetaDataInfo(file.FileName, file.Length);
            await _ingestionObserver.UpdateIngestionAsync(file, fileMetaData);
        }
    }
}
