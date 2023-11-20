namespace Store.Job.JsonConverter.Services.UpdateFileProcessingStatus;

using System.Linq.Expressions;
using Store.Job.JsonConverter.ValueObjects;

public interface IUpdateFileProcessingStatus
{
    Task UpdateAsync(FilePayloadMetaData entity);
}
