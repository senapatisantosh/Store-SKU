namespace Store.Job.JsonConverter.Services.UpdateFileProcessingStatus;

using Microsoft.EntityFrameworkCore;
using Store.Job.JsonConverter.ValueObjects;

public class UpdateFileProcessingStatusDbContext : DbContext
{
    public DbSet<FilePayloadMetaData> FilePayloadMetaDatas { get; set; }

    public UpdateFileProcessingStatusDbContext(DbContextOptions<UpdateFileProcessingStatusDbContext> options) : base(options)
    {

    }
}
