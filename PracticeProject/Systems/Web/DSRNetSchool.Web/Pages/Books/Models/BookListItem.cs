namespace DSRNetSchool.Web;

public class BookListItem
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public string Author { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
