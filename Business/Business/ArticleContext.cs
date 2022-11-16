using Business.ApplicationInterface;

namespace Business.Business;

public class ArticleContext : BaseContext<ArticlePage>
{
    public string GetArticleTitle()
    {
        Log.Info("Gettimg article title for opened page");
        return page.ArticleTitle.Text.Trim();
    }
}