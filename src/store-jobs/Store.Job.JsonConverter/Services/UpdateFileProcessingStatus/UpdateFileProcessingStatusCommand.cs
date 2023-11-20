namespace Store.Job.JsonConverter.Services.UpdateFileProcessingStatus;

using Store.Job.JsonConverter.Enums;
using Store.Job.JsonConverter.ValueObjects;

public class UpdateFileProcessingStatusCommand : IJsonConverterCommand, IJsonConverterCommandOrder
{
    private readonly IUpdateFileProcessingStatus _updateFileProcessingStatus;
    public int Order => 2;

    public UpdateFileProcessingStatusCommand(IUpdateFileProcessingStatus updateFileProcessingStatus)
    {
        _updateFileProcessingStatus = updateFileProcessingStatus;
    }

    public async Task ExecuteJsonConverterAync(FilePayloadMetaData fileMetaData)
    {
        fileMetaData.Status = IngestionStatus.Processing.ToString();
        await _updateFileProcessingStatus.UpdateAsync(fileMetaData);
    }
}
