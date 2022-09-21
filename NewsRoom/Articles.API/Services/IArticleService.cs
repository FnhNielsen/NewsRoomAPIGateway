using Articles.API.Models;

namespace Articles.API.Services;

public interface IArticleService
{
    List<Article> GetAll();
    Article GetArticle(int id);
    int Delete(int id);
}