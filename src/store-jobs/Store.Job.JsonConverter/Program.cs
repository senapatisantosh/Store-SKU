namespace Store.Job.JsonConverter;

using Store.Job.JsonConverter.Extensions;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services.ConigureApplication();
        builder.Services.ConigureSqlServerDb();
        builder.Services.ConfigureCoreApplicationScope();
        var host = builder.Build();
        host.Run();
    }
}
