using OpenQA.Selenium;

namespace Browser;

public class JsExecutor
{
    public static IJavaScriptExecutor Executor { private get; set; }

    private JsExecutor() {}

    public static IJavaScriptExecutor GetJsExecutor()
    {
        if (null == Executor)
        {
            InitParameters();
        }
        return Executor;
    }

    private static void InitParameters()
    {
        Executor ??= (IJavaScriptExecutor) Driver.GetDriver();
    }
}