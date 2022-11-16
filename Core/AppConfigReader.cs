using System.Configuration;
using log4net;

namespace Core;

public class AppConfigReader
{
    private static ILog Log
    {
        get { return LogManager.GetLogger("AppConfigReader"); }
    }

    private static string GetEnviromentVar(string key, string defaultValue)
    {   
        string? valueFromAppCongig = ConfigurationManager.AppSettings[key];
        if (null != valueFromAppCongig)
        {
            Log.Info($"{key} variable successfully receiced from App.config with value = {valueFromAppCongig}");
            return valueFromAppCongig;
        }
        else 
        {
            Log.Info($"There is not exist value for {key} in App.config file. So, for {key} will be taken default value = {defaultValue}");
            return defaultValue;
        }
    }

    public static string Browser => GetEnviromentVar("Browser", "Chrome");
    public static string Timeout => GetEnviromentVar("Timeout", "30");
}