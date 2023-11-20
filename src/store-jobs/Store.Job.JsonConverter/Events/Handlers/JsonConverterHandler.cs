namespace Store.Job.JsonConverter.Events.Handlers;

using Store.Job.JsonConverter.Services;
using Store.Job.JsonConverter.Services.KafkaMessageBus.Consumer;
using Store.Job.JsonConverter.ValueObjects;

public class JsonConverterHandler : IKafkaHandler<string, FilePayloadMetaData>
{
    private readonly IJsonConverterObserver _jsonConverterObserver;
    public JsonConverterHandler(IJsonConverterObserver jsonConverterObserver)
    {
        _jsonConverterObserver = jsonConverterObserver;
    }
    public async Task HandleAsync(string key, FilePayloadMetaData filePayloadMetaData)
    {
        await _jsonConverterObserver.UpdateJsonConverterProcessAsync(filePayloadMetaData);
    }
}
