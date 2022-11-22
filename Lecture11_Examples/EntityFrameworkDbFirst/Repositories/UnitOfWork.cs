using System.Data.Entity;
using EntityFrameworkDbFirst.DbContex;

namespace EntityFrameworkDbFirst.Data
{
    public class UnitOfWork
    {
        private DbContext context = new DSRNetSchoolSampleDbEntities();

        private IRepository<Article> articleRepository;
        private IRepository<Comment> commentRepository;

        public UnitOfWork()
        {
            articleRepository = new Repository<Article>(context);
            commentRepository = new Repository<Comment>(context);
        }

        public IRepository<Article> Articles => articleRepository;
        public IRepository<Comment> Comments => commentRepository;

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
