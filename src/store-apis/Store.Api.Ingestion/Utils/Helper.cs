using Store.Api.Ingestion.Enums;
using Store.Api.Ingestion.ValueObjects;
using System.Text;
using System.Text.RegularExpressions;

namespace Store.Api.Ingestion.Utils;

public class Helper
{
    public static FilePayloadMetaData GetFileMetaDataInfo(string fileName, double fileLength)
    {
        var storeId = GetStoreName(fileName);
        return new FilePayloadMetaData {
            UniqueStoreId = EncodeToBase64(storeId),
            FileName = fileName,
            StoreId = storeId,
            FileSizeInKB = fileLength / 1024.0,
            TimeStamp = DateTime.UtcNow,
            Status = IngestionStatus.Uploaded.ToString(),
        };
    }

    public static string EncodeToBase64(string plainText)
    {
        byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        return Convert.ToBase64String(plainTextBytes);
    }

    public static string DecodeFromBase64(string base64Encoded)
    {
        byte[] base64Bytes = Convert.FromBase64String(base64Encoded);
        return Encoding.UTF8.GetString(base64Bytes);
    }
    private static string GetStoreName(string fileName)
    {
        int lastUnderscoreIndex = fileName.LastIndexOf('_');
        string name = lastUnderscoreIndex >= 0 ? fileName.Substring(0, lastUnderscoreIndex) : fileName;
        return name;
    }

}
