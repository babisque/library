using Application.DTOs.Book;
using FluentValidation;

namespace Application.Validators.Book;

public class CreateBookValidator : AbstractValidator<CreateBookDTO>
{
    public CreateBookValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Author)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.ISBN)
            .NotEmpty()
            .Matches(@"^\d{13}$")
            .WithMessage("ISBN must be 13 digits");

        RuleFor(x => x.PublicationDate)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.UtcNow);

        RuleFor(x => x.Price)
            .GreaterThan(0);
    }
}