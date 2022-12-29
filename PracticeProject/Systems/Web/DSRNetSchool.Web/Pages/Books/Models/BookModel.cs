namespace DSRNetSchool.Web;

using FluentValidation;

public class BookModel
{
    public int? Id { get; set; }
    public int AuthorId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class BookModelValidator : AbstractValidator<BookModel>
{
    public BookModelValidator()
    {
        RuleFor(v => v.Title)
              .NotEmpty().WithMessage("Title is required")
              .MaximumLength(256).WithMessage("Title length must be less then 256")
              ;

        RuleFor(v => v.AuthorId)
            .GreaterThan(0).WithMessage("Please, select an user");

        RuleFor(v => v.Description)
             .MaximumLength(1024).WithMessage("Description length must be less then 1024");
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<BookModel>.CreateWithOptions((BookModel)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}