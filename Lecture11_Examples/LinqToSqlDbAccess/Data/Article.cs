using LinqToDB.Mapping;

namespace LinqToSqlDbAccess.Data
{
    [Table(Name = "articles")]
    public class Article : BaseEntity
    {
        [Column]
        public string Title { get; set; }

        [Column]
        public string Text { get; set; }
    }
}
