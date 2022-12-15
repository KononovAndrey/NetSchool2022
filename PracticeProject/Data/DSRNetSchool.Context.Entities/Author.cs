namespace DSRNetSchool.Context.Entities;

public class Author : BaseEntity
{
    public string Name { get; set; }
    public virtual AuthorDetail Detail { get; set; }

    public virtual ICollection<Book> Books { get; set; }
}
