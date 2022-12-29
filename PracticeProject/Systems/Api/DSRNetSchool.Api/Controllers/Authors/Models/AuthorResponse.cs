namespace DSRNetSchool.API.Controllers.Authors.Models;

using AutoMapper;
using DSRNetSchool.Services.Authors;

public class AuthorResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class AuthorResponseProfile : Profile
{
    public AuthorResponseProfile()
    {
        CreateMap<AuthorModel, AuthorResponse>();
    }
}
