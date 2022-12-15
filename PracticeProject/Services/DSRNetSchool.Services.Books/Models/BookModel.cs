namespace DSRNetSchool.Services.Books;

using AutoMapper;
using DSRNetSchool.Context.Entities;

public class BookModel
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public string Author { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
}

public class BookModelProfile : Profile
{
    public BookModelProfile()
    {
        CreateMap<Book, BookModel>()
            .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name));
    }
}
