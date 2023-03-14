using Microsoft.Extensions.Configuration;

namespace EHospital.Persistence;

public static class Configuration
{
    public static ConfigurationManager ConfigManager
    {
        get
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "Presentation", "EHospital.API"));
            configurationManager.AddJsonFile("appsettings.json");
            return configurationManager;
        }
    }

    public static string ConnectionString
    {
        get
        {
            return ConfigManager.GetConnectionString("Default");
        }
    }

}
