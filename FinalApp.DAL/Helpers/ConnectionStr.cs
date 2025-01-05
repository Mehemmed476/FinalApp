using Microsoft.Extensions.Configuration;

namespace FinalApp.DAL.Helpers;

public class ConnectionStr
{
    public static string GetConnectionString()
    {
        ConfigurationManager configurationManager = new ConfigurationManager();
        configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "FinalApp.API"));
        configurationManager.AddJsonFile("appsettings.json");
        
        string? connectionString = configurationManager.GetConnectionString("MacBookMsSql");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new Exception("No connection string found.");
        }
        
        return connectionString;
    }
}