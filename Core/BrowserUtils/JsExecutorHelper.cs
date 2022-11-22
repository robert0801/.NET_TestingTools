using log4net;
using OpenQA.Selenium;

namespace Core.BrowserUtils;

public class JsExecutorHelper
{
    private static IJavaScriptExecutor? executor;

    private JsExecutorHelper() {}

    private static ILog Log
    {
        get => LogManager.GetLogger("JsExecutorHelper");
    }

    public static IJavaScriptExecutor GetJsExecutor()
    {
        if (null == executor)
        {
            Log.Info("IJavaScriptExecutor is NULL. Creating a new instance for JsExecutorHelper...");
            InitParameters();
        }
        if (null != executor) return executor;
        else 
        {
            Log.Error("Exception during JsExecutorHelper executor initialization.");
            throw new Exception("Exception during JsExecutorHelper executor initialization.");
        }
    }

    public static void DestroyJsExecutorHelper()
    {
        Log.Info("Destroying currect JsExecutorHelper instance...");
        executor = null;
    }

    private static void InitParameters()
    {
        executor = (IJavaScriptExecutor) DriverHelper.GetDriver();
    } 
}