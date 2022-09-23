using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Articles.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Articles.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly ArticleService _articleService;
        public ArticlesController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_articleService.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetArticle(int id)
        {
            var article = _articleService.GetArticle(id);
            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteArticle(int id)
        {
            var articleId = _articleService.Delete(id);
            if (articleId == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
