using Dapper;

namespace DapperDbAccess.Data
{
    public class ArticleRepository : IArticleRepository
    {
        public IEnumerable<Article> GetAll()
        {
            var sql = @"SELECT [Id], [Uid], [Title], [Text] FROM [dbo].[Articles]";

            using var factory = new Db();
            using var connection = factory.GetConnection();

            var result = connection.Query<Article>(sql).ToList();

            return result;
        }

        public Article GetById(int id)
        {
            var sql = $@"SELECT [Id], [Uid], [Title], [Text] FROM [dbo].[Articles] WHERE [Id] = @id";

            using var factory = new Db();
            using var connection = factory.GetConnection();

            var result = connection.Query<Article>(sql, new {id = id}).FirstOrDefault();

            return result;
        }

        public void Insert(Article data)
        {
            var sql = $@"INSERT INTO [dbo].[Articles] ([Uid], [Title], [Text]) VALUES (@uid, @title, @text)";

            using var factory = new Db();
            using var connection = factory.GetConnection();

            var result = connection.Execute(sql, new { uid = Guid.NewGuid(), title = data.Title, text = data.Text  });
        }

        public void Update(Article data)
        {
            var sql = $@"UPDATE [dbo].[Articles] SET [Title] = @title, [Text] = @text WHERE [Id] = @id";

            using var factory = new Db();
            using var connection = factory.GetConnection();

            var result = connection.Execute(sql, new { id = data.Id, title = data.Title, text = data.Text });
        }

        public void Remove(int id)
        {
            var sql = $@"DELETE FROM [dbo].[Articles] WHERE [Id] = @id";

            using var factory = new Db();
            using var connection = factory.GetConnection();

            var result = connection.Execute(sql, new { id = id });
        }
    }
}
