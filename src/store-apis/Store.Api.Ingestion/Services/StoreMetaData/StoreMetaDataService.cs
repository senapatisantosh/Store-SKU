namespace Store.Api.Ingestion.Services.StoreMetaData;

using Microsoft.EntityFrameworkCore;
using Store.Api.Ingestion.ValueObjects;
using System.Linq.Expressions;

public class StoreMetaDataService : IStoreMetaDataService
{
    private readonly StoreMetaDataDbContext _storeMetaDataDbContext;
    public StoreMetaDataService(StoreMetaDataDbContext storeMetaDataDbContext)
    {
        _storeMetaDataDbContext = storeMetaDataDbContext;
    }
    public async Task<IEnumerable<FilePayloadMetaData>> GetAllAsync()
    {
        return await _storeMetaDataDbContext.FilePayloadMetaDatas.ToListAsync();
    }

    public async Task<IEnumerable<FilePayloadMetaData>> FindAsync(Expression<Func<FilePayloadMetaData, bool>> predicate)
    {
        return await _storeMetaDataDbContext.FilePayloadMetaDatas.Where(predicate).ToListAsync();
    }

    public async Task<FilePayloadMetaData?> GetByIdAsync(int id)
    {
        return await _storeMetaDataDbContext.FilePayloadMetaDatas.FindAsync(id);
    }

    public async Task AddAsync(FilePayloadMetaData filePayloadMetaData)
    {
        await _storeMetaDataDbContext.FilePayloadMetaDatas.AddAsync(filePayloadMetaData);
        await _storeMetaDataDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(FilePayloadMetaData filePayloadMetaData)
    {
        _storeMetaDataDbContext.FilePayloadMetaDatas.Update(filePayloadMetaData);
        await _storeMetaDataDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var filePayloadMetaData = await _storeMetaDataDbContext.FilePayloadMetaDatas.FindAsync(id);
        if (filePayloadMetaData != null)
        {
            _storeMetaDataDbContext.FilePayloadMetaDatas.Remove(filePayloadMetaData);
            await _storeMetaDataDbContext.SaveChangesAsync();
        }
    }
}
