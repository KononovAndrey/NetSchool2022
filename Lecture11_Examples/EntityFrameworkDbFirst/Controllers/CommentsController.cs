using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EntityFrameworkDbFirst.Data;
using EntityFrameworkDbFirst.DbContex;

namespace EntityFrameworkDbFirst.Controllers
{
    public class CommentsController : ApiController
    {
        private readonly CommentRepository repository = new CommentRepository();

        [HttpGet]
        [ActionName("comments")]
        public IEnumerable<Comment> GetAllComments()
        {
            var result = repository.Data.GetAll();
            return result;
        }

        [HttpPost]
        [ActionName("comments")]
        public IHttpActionResult InsertComment(int ArticleId, string Author, string Text)
        {
            repository.Data.Insert(new Comment()
            {
                ArticleId = ArticleId,
                Author = Author,
                Text = Text
            });
            repository.Data.GetContext().SaveChanges();

            return Ok();
        }

        [HttpPut]
        [ActionName("comments")]
        public IHttpActionResult UpdateComment(int id, string Author, string Text)
        {
            var comment = repository.Data.GetAll().FirstOrDefault(x => x.Id == id);

            comment.Author = Author;
            comment.Text = Text;

            repository.Data.Update(comment);
            repository.Data.GetContext().SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [ActionName("comments")]
        public IHttpActionResult DeleteComment(int id)
        {
            var comment = repository.Data.GetAll().FirstOrDefault(x => x.Id == id);

            repository.Data.Delete(comment);
            repository.Data.GetContext().SaveChanges();

            return Ok();
        }
    }
}