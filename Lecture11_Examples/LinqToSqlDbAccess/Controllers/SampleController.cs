using LinqToSqlDbAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace LinqToSqlDbAccess.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly ILogger<SampleController> _logger;
        private readonly IRepository<Article> articleRepository;
        private readonly IRepository<Comment> commentRepository;

        public SampleController(ILogger<SampleController> logger, IRepository<Article> articleRepository, IRepository<Comment> commentRepository)
        {
            _logger = logger;
            this.articleRepository = articleRepository;
            this.commentRepository = commentRepository;
        }

        [HttpGet("article")]
        public IEnumerable<Article> GetAllArticles()
        {
            var result = articleRepository.GetAll();
            return result;
        }

        [HttpPost("article")]
        public IActionResult InsertArticle(string Title, string Text)
        {
            articleRepository.Insert(new Article()
            {
                Title = Title,
                Text = Text
            });
            return Ok();
        }

        [HttpPut("article")]
        public IActionResult UpdateArticle(int id, string Title, string Text)
        {
            var article = articleRepository.GetById(id);

            article.Title = Title;
            article.Text = Text;

            articleRepository.Update(article);
            return Ok();
        }

        [HttpDelete("article")]
        public IActionResult DeleteArticle(int id)
        {
            var article = articleRepository.GetById(id);

            articleRepository.Delete(article);
            return Ok();
        }



        [HttpGet("comment")]
        public IEnumerable<Comment> GetAllComments()
        {
            var result = commentRepository.GetAll();
            return result;
        }

        [HttpPost("comment")]
        public IActionResult InsertComment(int ArticleId, string Author, string Text)
        {
            commentRepository.Insert(new Comment()
            {
                ArticleId = ArticleId,
                Author = Author,
                Text = Text
            });
            return Ok();
        }

        [HttpPut("comment")]
        public IActionResult UpdateComment(int id, string Author, string Text)
        {
            var comment = commentRepository.GetById(id);

            comment.Author = Author;
            comment.Text = Text;

            commentRepository.Update(comment);
            return Ok();
        }

        [HttpDelete("comment")]
        public IActionResult DeleteComment(int id)
        {
            var comment = commentRepository.GetById(id);

            commentRepository.Delete(comment);
            return Ok();
        }
    }
}