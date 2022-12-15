namespace DSRNetSchool.API.Controllers.Models;

using AutoMapper;
using DSRNetSchool.Services.Books;

public class BookResponse
{
    /// <summary>
    /// Book Id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Book title
    /// </summary>
    public string Title { get; set; } = string.Empty;
    public int AuthorId { get; set; }
    public string Author { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class BookResponseProfile : Profile
{
    public BookResponseProfile()
    {
        CreateMap<BookModel, BookResponse>()
            .ForMember(d => d.Description, a => a.MapFrom(s => s.Note));
    }
}
