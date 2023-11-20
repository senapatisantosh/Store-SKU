namespace Store.Mock.Data;

using CsvHelper;
using Store.Mock.Data.ValueObjects;
using System.Diagnostics.Metrics;
using System.Globalization;


public class WriteDataToCsv
{
    public static void WriteStoreSkuDataToCsv(string dropLoacation, string uniqueStoreId, IEnumerable<StoreSkuModel> storeSkuModels)
    {
        if (!Directory.Exists(dropLoacation))
        {
            Directory.CreateDirectory(dropLoacation);
        }
        string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
        string fileName = $"{uniqueStoreId}_{timestamp}.csv";
        string filePath = Path.Combine(dropLoacation, fileName);

        using var writer = new StreamWriter(filePath);
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csv.WriteRecords(storeSkuModels);
    }
}
