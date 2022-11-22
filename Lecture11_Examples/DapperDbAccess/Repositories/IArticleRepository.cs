namespace DapperDbAccess.Data
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetAll();
        Article GetById(int id);
        void Insert(Article data);
        void Update(Article data);
        void Remove(int id);
    }
}
