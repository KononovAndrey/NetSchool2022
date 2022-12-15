namespace DSRNetSchool.Context.Entities;

public class Category : BaseEntity
{
    public string Title { get; set; }
    public virtual ICollection<Book> Books { get; set; }
}
