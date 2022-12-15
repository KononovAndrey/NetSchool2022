namespace DSRNetSchool.API.Controllers.Models;

using AutoMapper;
using DSRNetSchool.Services.Books;
using FluentValidation;

public class AddBookRequest
{
    public int AuthorId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class AddBookResponseValidator : AbstractValidator<AddBookRequest>
{
    public AddBookResponseValidator()
    {
        RuleFor(x => x.AuthorId)
            .NotEmpty().WithMessage("Author is required.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(50).WithMessage("Title is long.");

        RuleFor(x => x.Description)
            .MaximumLength(2000).WithMessage("Description is long.");
    }
}

public class AddBookRequestProfile : Profile
{
    public AddBookRequestProfile()
    {
        CreateMap<AddBookRequest, AddBookModel>()
            .ForMember(d => d.Note, a => a.MapFrom(s => s.Description));
    }
}

