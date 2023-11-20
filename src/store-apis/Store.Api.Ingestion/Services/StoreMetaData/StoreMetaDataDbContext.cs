namespace Store.Api.Ingestion.Services.StoreMetaData;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Store.Api.Ingestion.ValueObjects;

public class StoreMetaDataDbContext : DbContext
{
    public DbSet<FilePayloadMetaData> FilePayloadMetaDatas { get; set; }

    public StoreMetaDataDbContext(DbContextOptions<StoreMetaDataDbContext> options) : base(options) { 
        try
        {
            var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            if(databaseCreator is not null)
            {
                if (!databaseCreator.CanConnect()) databaseCreator.Create();

                if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

}
