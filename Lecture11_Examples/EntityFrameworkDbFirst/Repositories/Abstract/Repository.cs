using System.Data.Entity;
using System.Linq;
using EntityFrameworkDbFirst.DbContex;

namespace EntityFrameworkDbFirst.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbContext context;

        public Repository(DbContext context)
        {
            this.context = context ?? new DSRNetSchoolSampleDbEntities();
        }

        public DbContext GetContext()
        {
            return context;
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public void Insert(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Deleted;
        }
    }
}
