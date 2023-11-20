namespace Store.Api.Ingestion.Services.StoreMetaData;

using Store.Api.Ingestion.ValueObjects;
using System.Linq.Expressions;

public interface IStoreMetaDataService
{
    Task<IEnumerable<FilePayloadMetaData>> GetAllAsync();
    Task<IEnumerable<FilePayloadMetaData>> FindAsync(Expression<Func<FilePayloadMetaData, bool>> predicate);
    Task<FilePayloadMetaData?> GetByIdAsync(int id);
    Task AddAsync(FilePayloadMetaData entity);
    Task UpdateAsync(FilePayloadMetaData entity);
    Task DeleteAsync(int id);
}
