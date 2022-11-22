using System.Data.Entity;
using EntityFrameworkDbFirst.DbContex;

namespace EntityFrameworkDbFirst.Data
{
    public class ArticleRepository
    {
        private DbContext context;
        private Repository<Article> repository;

        public ArticleRepository(DbContext context)
        {
            this.context = context ?? new DSRNetSchoolSampleDbEntities();
            repository = new Repository<Article>(this.context);
        }

        public IRepository<Article> Data => repository;
    }
}
