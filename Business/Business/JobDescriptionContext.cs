using Business.ApplicationInterface;

namespace Business.Business;

public class JobDescriptionContext : BaseContext<JobDescriptionPage>
{    
    public string GetJobTitle()
    {
        Log.Info("Getting Job title for chosen possition.");
        return page.PageTitle.Text;
    }
}