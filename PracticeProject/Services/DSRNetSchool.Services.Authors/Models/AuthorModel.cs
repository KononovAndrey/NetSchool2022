namespace DSRNetSchool.Services.Authors;

using AutoMapper;
using DSRNetSchool.Context.Entities;

public class AuthorModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class AuthorModelProfile : Profile
{
    public AuthorModelProfile()
    {
        CreateMap<Author, AuthorModel>();
    }
}
