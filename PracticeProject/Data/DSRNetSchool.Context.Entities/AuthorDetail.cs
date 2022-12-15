namespace DSRNetSchool.Context.Entities;

using System.ComponentModel.DataAnnotations;

public class AuthorDetail
{
    [Key]
    public int Id { get; set; }
    public virtual Author Author { get; set; }

    public string Family { get; set; }
    public string Country { get; set; }
}
