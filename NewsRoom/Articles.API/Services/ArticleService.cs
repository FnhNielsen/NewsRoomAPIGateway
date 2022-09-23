using Articles.API.Models;

namespace Articles.API.Services;

public class ArticleService : IArticleService
{
    private readonly static List<Article> _articles = Populate();
    private static List<Article> Populate()
    {
        var result = new List<Article>()
        {
            new Article()
            {
                Id = 1,
                Title = "First title",
                Created = DateTime.Today,
                LastUpdate = DateTime.Now,
                WriterId = 2
            },
            new Article
            {
                Id = 2,
                Title = "Second title",
                Created = DateTime.Today,
                LastUpdate = DateTime.Now,
                WriterId = 2
            },
            new Article
            {
                Id = 3,
                Title = "Third title",
                Created = DateTime.Today,
                LastUpdate = DateTime.Now,
                WriterId = 1
            }
        };
        return result;
    }

    public List<Article> GetAll()
    {
        return _articles;
    }

    public Article GetArticle(int id)
    {
        return _articles.FirstOrDefault(a => a.Id == id) ?? throw new InvalidOperationException();
    }

    public int Delete(int id)
    {
        var removed = _articles.SingleOrDefault(x => x.Id == id);
        if (removed != null)
            _articles.Remove(removed);
        return removed?.Id ?? 0;
    }
}