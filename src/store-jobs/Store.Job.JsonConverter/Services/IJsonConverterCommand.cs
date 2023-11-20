namespace Store.Job.JsonConverter.Services;

using Store.Job.JsonConverter.ValueObjects;

public interface IJsonConverterCommand
{
    Task ExecuteJsonConverterAync(FilePayloadMetaData fileMetaData);
}
