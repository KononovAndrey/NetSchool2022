namespace DSRNetSchool.Context.Entities;

public class Book : BaseEntity
{
    public int? AuthorId { get; set; }
    public virtual Author Author { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }

    public virtual ICollection<Category> Categories { get; set; }
}
