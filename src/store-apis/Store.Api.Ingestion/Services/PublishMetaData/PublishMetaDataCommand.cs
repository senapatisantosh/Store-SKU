using Store.Api.Ingestion.ValueObjects;

namespace Store.Api.Ingestion.Services.PublishMetaData;

public class PublishMetaDataCommand : IIngestionCommand, IIngestionCommandOrder
{
    private readonly IKafkaMessageBus<string, FilePayloadMetaData> _kafkaMessageBus;
    public int Order => 3;

    public PublishMetaDataCommand(IKafkaMessageBus<string, FilePayloadMetaData> kafkaMessageBus)
    {
        _kafkaMessageBus = kafkaMessageBus;
    }

    public async Task ExecuteIngestionAync(IFormFile file, FilePayloadMetaData fileMetaData)
    {
        await _kafkaMessageBus.PublishAsync(Guid.NewGuid().ToString(), fileMetaData);
    }
}
