namespace Store.Job.JsonConverter.Services.KafkaMessageBus;

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ChoETL;
using Microsoft.Extensions.Options;
using Store.Job.JsonConverter.Configs;
using Store.Job.JsonConverter.ValueObjects;

public class PublishJsonDataCommand : IJsonConverterCommand, IJsonConverterCommandOrder
{
    private readonly IKafkaMessageBus<string, StoreSku> _kafkaMessageBus;
    private readonly IOptions<StorageLocationOptions> _storageLocationOptions;

    public int Order => 1;

    public PublishJsonDataCommand(IKafkaMessageBus<string, StoreSku> kafkaMessageBus, IOptions<StorageLocationOptions> storageLocationOptions)
    {
        _kafkaMessageBus = kafkaMessageBus;
        _storageLocationOptions = storageLocationOptions;
    }

    public async Task ExecuteJsonConverterAync(FilePayloadMetaData fileMetaData)
    {
        var filePath = Path.Combine(_storageLocationOptions.Value.CsvStorage, fileMetaData.FileName!);
        try
        {
            var storeSkuRows = new ChoCSVReader<StoreSku>(filePath).WithFirstLineHeader().ToList();
            var publishTasks = storeSkuRows.Select(row =>
            {
                return _kafkaMessageBus.PublishAsync(Guid.NewGuid().ToString(), row);
            });
            await Task.WhenAll(publishTasks);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading CSV file: {ex.Message}");
        }
    }
}
