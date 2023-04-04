namespace CRUD_Products.Models.DataAccess;
using System.Configuration;

public class Connection : IConnection
{
    public string GetConnectionStringAppSettings()
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        var configuration = builder.Build();

        var connectionString = configuration.GetConnectionString("connectionString");

        return connectionString;
    }
}
