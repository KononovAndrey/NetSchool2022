namespace DapperDbAccess.Data
{
    public class Comment : BaseEntity
    {
        public int ArticleId { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
    }
}
