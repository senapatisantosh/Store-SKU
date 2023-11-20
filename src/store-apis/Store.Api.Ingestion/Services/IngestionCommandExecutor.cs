using Store.Api.Ingestion.ValueObjects;

namespace Store.Api.Ingestion.Services;

public class IngestionCommandExecutor : IIngestionObserver
{
    private readonly IEnumerable<IIngestionCommand> ingestionCommands;

    public IngestionCommandExecutor(IEnumerable<IIngestionCommand> allIngestionCommands)
    {
        ingestionCommands = allIngestionCommands.OrderBy(c => (c as IIngestionCommandOrder)?.Order);
    }

    public async Task UpdateIngestionAsync(IFormFile file, FilePayloadMetaData fileMetaData)
    {
        foreach (var ingestionCommand in ingestionCommands)
        {
            await ingestionCommand.ExecuteIngestionAync(file, fileMetaData);
        }
    }
}
