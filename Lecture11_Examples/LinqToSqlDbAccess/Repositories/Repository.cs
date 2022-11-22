using LinqToDB;
using LinqToDB.Data;

namespace LinqToSqlDbAccess.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DataConnection connection;

        public Repository(DataConnection connection)
        {
            this.connection = connection;
        }

        public IQueryable<T> GetAll()
        {
            return connection.GetTable<T>();
        }

        public T GetById(int id)
        {
            return connection.GetTable<T>().FirstOrDefault(x => x.Id == id);
        }

        public void Insert(T entity)
        {
            connection.Insert(entity);
        }

        public void Update(T entity)
        {
            connection.Update(entity);
        }

        public void Delete(T entity)
        {
            connection.Delete(entity);
        }
    }
}
