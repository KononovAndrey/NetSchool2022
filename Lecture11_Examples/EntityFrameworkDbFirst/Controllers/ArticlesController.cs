using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EntityFrameworkDbFirst.Data;
using EntityFrameworkDbFirst.DbContex;

namespace EntityFrameworkDbFirst.Controllers
{
    public class ArticlesController : ApiController
    {
        private readonly UnitOfWork uow = new UnitOfWork();

        [HttpGet]
        public IEnumerable<Article> GetAllArticles()
        {
            var result = uow.Articles.GetAll();
            return result;
        }

        [HttpPost]
        public IHttpActionResult InsertArticle(string Title, string Text)
        {
            uow.Articles.Insert(new Article()
            {
                Title = Title,
                Text = Text
            });
            uow.Articles.Insert(new Article()
            {
                Title = Title+"_1",
                Text = Text + "_1"
            }); 
            uow.Articles.Insert(new Article()
            {
                Title = Title + "_2",
                Text = Text + "_2"
            });


            uow.Commit();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateArticle(int id, string Title, string Text)
        {
            var article = uow.Articles.GetAll().FirstOrDefault(x => x.Id == id);

            article.Title = Title;
            article.Text = Text;

            uow.Articles.Update(article);
            uow.Commit();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteArticle(int id)
        {
            var article = uow.Articles.GetAll().FirstOrDefault(x => x.Id == id);

            uow.Articles.Delete(article);
            uow.Commit();

            return Ok();
        }
    }
}