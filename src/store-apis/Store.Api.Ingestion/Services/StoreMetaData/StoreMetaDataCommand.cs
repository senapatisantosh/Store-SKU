namespace Store.Api.Ingestion.Services.StoreMetaData;

using Store.Api.Ingestion.ValueObjects;

public class StoreMetaDataCommand : IIngestionCommand, IIngestionCommandOrder
{
    private readonly IStoreMetaDataService _storeMetaDataService;
    public int Order => 2;

    public StoreMetaDataCommand(IStoreMetaDataService storeMetaDataService)
    {
        _storeMetaDataService = storeMetaDataService;
    }

    public async Task ExecuteIngestionAync(IFormFile file, FilePayloadMetaData fileMetaData)
    {
        await _storeMetaDataService.AddAsync(fileMetaData);
    }
}