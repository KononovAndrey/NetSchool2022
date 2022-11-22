namespace DirectDbAccess.Data
{
    public class ArticleRepository : IArticleRepository
    {
        public IEnumerable<Article> GetAll()
        {
            var sql = @"SELECT [Id], [Uid], [Title], [Text] FROM [dbo].[Articles]";

            using var factory = new Db();
            using var connection = factory.GetConnection();
            using var reader = factory.GetData(connection, sql);

            var result = new List<Article>();
            while (reader.Read())
            {
                result.Add(new Article()
                {
                    Id = reader.GetInt32(0),
                    Uid = reader.GetGuid(1),
                    Text = reader.GetString(2),
                    Title = reader.GetString(3),
                });
            }

            return result;
        }

        public Article GetById(int id)
        {
            var sql = $@"SELECT [Id], [Uid], [Title], [Text] FROM [dbo].[Articles] WHERE [Id] = {id}";

            using var factory = new Db();
            using var connection = factory.GetConnection();
            using var reader = factory.GetData(connection, sql);

            Article result = null;
            if (reader.Read())
            {
                result = new Article()
                {
                    Id = reader.GetInt32(0),
                    Uid = reader.GetGuid(1),
                    Text = reader.GetString(2),
                    Title = reader.GetString(3),
                };
            }

            return result;
        }

        public void Insert(Article data)
        {
            var sql = $@"INSERT INTO [dbo].[Articles] ([Uid], [Title], [Text]) VALUES ('{Guid.NewGuid()}', '{data.Title}', '{data.Text}')";

            using var factory = new Db();
            using var connection = factory.GetConnection();
            factory.ExecuteCommand(connection, sql);
        }

        public void Update(Article data)
        {
            var sql = $@"UPDATE [dbo].[Articles] SET [Title] = '{data.Title}', [Text] = '{data.Text}' WHERE [Id] = {data.Id}";

            using var factory = new Db();
            using var connection = factory.GetConnection();
            factory.ExecuteCommand(connection, sql);
        }

        public void Remove(int id)
        {
            var sql = $@"DELETE FROM [dbo].[Articles] WHERE [Id] = '{id}'";

            using var factory = new Db();
            using var connection = factory.GetConnection();
            factory.ExecuteCommand(connection, sql);
        }
    }
}
