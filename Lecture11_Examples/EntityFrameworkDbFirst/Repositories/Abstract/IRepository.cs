using System.Data.Entity;
using System.Linq;

namespace EntityFrameworkDbFirst.Data
{
    public interface IRepository<T> where T : class
    {
        DbContext GetContext();
        IQueryable<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}