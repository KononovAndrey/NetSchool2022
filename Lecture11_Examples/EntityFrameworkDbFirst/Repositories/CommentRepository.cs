using System.Data.Entity;
using EntityFrameworkDbFirst.DbContex;

namespace EntityFrameworkDbFirst.Data
{
    public class CommentRepository
    {
        private DbContext context;
        private Repository<Comment> repository;

        public CommentRepository(DbContext context = null)
        {
            this.context = context ?? new DSRNetSchoolSampleDbEntities();
            repository = new Repository<Comment>(this.context);
        }

        public IRepository<Comment> Data => repository;
    }
}
