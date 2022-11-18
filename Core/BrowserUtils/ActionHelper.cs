using log4net;
using OpenQA.Selenium.Interactions;

namespace Core.BrowserUtils;

public class ActionHelper
{
    private static Actions? actions;

    private ActionHelper() {}

    private static ILog Log
    {
        get { return LogManager.GetLogger("ActionHelper"); }
    }

    public static Actions GetActions()
    {
        if (null == actions)
        {
            Log.Info("Actions is NULL. Creating a new instance for ActionHelper...");
            InitParameters();
        }
        if (null != actions) return actions;
        else 
        {
            Log.Error("Exception during ActionHelper initialization.");
            throw new Exception("Exception during Actions initialization.");
        }
    }

    public static void DestroyActionHelper()
    {
        Log.Info("Destroying currect Action instance...");
        actions = null;
    }

    private static void InitParameters()
    {
        actions = new Actions(DriverHelper.GetDriver());
    }
}