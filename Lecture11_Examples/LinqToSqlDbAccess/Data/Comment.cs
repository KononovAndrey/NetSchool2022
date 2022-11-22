using LinqToDB.Mapping;

namespace LinqToSqlDbAccess.Data
{
    [Table(Name = "comments")]
    public class Comment : BaseEntity
    {
        [Column]
        public int ArticleId { get; set; }

        [Column]
        public string Author { get; set; }

        [Column]
        public string Text { get; set; }
    }
}
