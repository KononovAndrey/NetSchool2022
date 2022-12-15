namespace DSRNetSchool.Services.Books;

using AutoMapper;
using DSRNetSchool.Context.Entities;
using FluentValidation;

public class UpdateBookModel
{
    public int AuthorId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
}

public class UpdateBookModelValidator : AbstractValidator<UpdateBookModel>
{
    public UpdateBookModelValidator()
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

public class UpdateBookModelProfile : Profile
{
    public UpdateBookModelProfile()
    {
        CreateMap<UpdateBookModel, Book>()
            .ForMember(d => d.Description, a => a.MapFrom(s => s.Note));
    }
}