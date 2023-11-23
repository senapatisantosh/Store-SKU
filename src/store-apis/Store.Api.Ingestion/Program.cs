namespace Store.Api.Ingestion;

using Microsoft.OpenApi.Models;
using Store.Api.Ingestion.Extensions;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.ConigureApplication();
        builder.Services.ConigureCors();
        builder.Services.ConigureSqlServerDb();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Store Ingestion API", Version = "v1" });
        });

        builder.Services.ConigureCoreApplicationScope();


        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Store Ingestion API");
        });

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseCors("StoreIngestionApi");

        app.MapControllers();

        app.Run();
    }
}