namespace Store.Job.JsonConverter.Services.UpdateFileProcessingStatus;

using Store.Job.JsonConverter.ValueObjects;

public class UpdateFileProcessingStatus : IUpdateFileProcessingStatus
{
    private readonly UpdateFileProcessingStatusDbContext _updateFileProcessingStatusDbContext;

    public UpdateFileProcessingStatus(UpdateFileProcessingStatusDbContext updateFileProcessingStatusDbContext)
    {
        _updateFileProcessingStatusDbContext = updateFileProcessingStatusDbContext;
    }

    public async Task UpdateAsync(FilePayloadMetaData filePayloadMetaData)
    {
        _updateFileProcessingStatusDbContext.FilePayloadMetaDatas.Update(filePayloadMetaData);
        await _updateFileProcessingStatusDbContext.SaveChangesAsync();
    }
}
