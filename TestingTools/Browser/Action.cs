using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Browser;

public class Action
{
    public static Actions Actions { private get; set; } 

    private Action() {}

    public static Actions GetActions()
    {
        if (null == Actions)
        {
            InitParameters();
        }
        return Actions;
    }

    private static void InitParameters()
    {
        Actions = new Actions(Driver.GetDriver());
    }
}