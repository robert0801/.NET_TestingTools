using log4net;
using Microsoft.Extensions.Configuration;

namespace Core;

public class ConfigurationReader
{
    private static IConfigurationRoot? rootConfig;
    private static ILog Log
    {
        get { return LogManager.GetLogger("AppConfigReader"); }
    }

    private ConfigurationReader() 
    {
        IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile(Directory.GetCurrentDirectory() + "../../../../Configuration.json", false, true);
        rootConfig = builder.Build();
    }

    public static string Browser => GetEnviromentVar("Browser", "Chrome");
    public static string Timeout => GetEnviromentVar("Timeout", "30");

    private static IConfigurationRoot? GetConfigurationReader()
    {
        if (null == rootConfig)
        {
            new ConfigurationReader();
        }
        return rootConfig;
    }

    private static string GetEnviromentVar(string key, string defaultValue)
    {   
        try
        {
            var config = GetConfigurationReader();
            string? valueFromConfig = config[key];
            if (null != valueFromConfig)
            {
                Log.Info($"{key} variable successfully receiced from Configuration.json with value = {valueFromConfig}");
                return valueFromConfig;
            }
            else 
            {
                Log.Info($"There is not exist value for {key} in Configuration.json file. So, for {key} will be taken default value = {defaultValue}");
                return defaultValue;
            }
        }
        catch (FileNotFoundException ex)
        {
            Log.Error("Exception during IConfigurationRoot initialization.\n" + ex.Message);
            throw;
        }
    }
}