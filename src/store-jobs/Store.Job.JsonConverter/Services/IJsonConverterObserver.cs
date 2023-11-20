namespace Store.Job.JsonConverter.Services;

using Store.Job.JsonConverter.ValueObjects;

public interface IJsonConverterObserver
{
    Task UpdateJsonConverterProcessAsync(FilePayloadMetaData fileMetaData);
}