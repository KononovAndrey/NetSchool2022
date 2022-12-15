namespace DSRNetSchool.Services.Books;

using AutoMapper;
using DSRNetSchool.Context.Entities;
using FluentValidation;

public class AddBookModel
{
    public int AuthorId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
}

public class AddBookModelValidator : AbstractValidator<AddBookModel>
{
    public AddBookModelValidator()
    {
        RuleFor(x => x.AuthorId)
            .NotEmpty().WithMessage("Author is required.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(50).WithMessage("Title is long.");

        RuleFor(x => x.Note)
            .MaximumLength(2000).WithMessage("Description is long.");
    }
}

public class AddBookModelProfile : Profile
{
    public AddBookModelProfile()
    {
        CreateMap<AddBookModel, Book>()
            .ForMember(d => d.Description, a => a.MapFrom(s => s.Note));
    }
}