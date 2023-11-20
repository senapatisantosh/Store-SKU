using Store.Job.JsonConverter.ValueObjects;

namespace Store.Job.JsonConverter.Services;

public class JsonConverterCommandExecuter : IJsonConverterObserver
{
    private readonly IEnumerable<IJsonConverterCommand> jsonConverterCommands;

    public JsonConverterCommandExecuter(IEnumerable<IJsonConverterCommand> allJsonConverterCommands)
    {
        jsonConverterCommands = allJsonConverterCommands.OrderBy(c => (c as IJsonConverterCommandOrder)?.Order);
    }

    public async Task UpdateJsonConverterProcessAsync(FilePayloadMetaData fileMetaData)
    {
        foreach (var jsonConverterCommand in jsonConverterCommands)
        {
            await jsonConverterCommand.ExecuteJsonConverterAync(fileMetaData);
        }
    }
}
