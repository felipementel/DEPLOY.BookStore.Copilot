using DEPLOY.BookStore.Domain.Aggregates.BookPublisher.Interfaces.Repositories;
using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace DEPLOY.BookStore.Domain.Aggregates.BookPublisher.Validators
{
    [ExcludeFromCodeCoverage]
    public class BookPublisherValidator : AbstractValidator<Entities.BookPublisher>
    {
        private readonly IBookPublisherRepository _bookRepository;

        public BookPublisherValidator(IBookPublisherRepository bookPublisherRepository)
        {
            _bookRepository = bookPublisherRepository;

            RuleSet("new", () =>
            {
                RuleFor(e => e.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} can not be empty");

                RuleFor(e => e.Name)
                .MustAsync(async (name, cancellation) =>
                    !await _bookRepository.BookExistsAsync(name))
                .WithMessage("A book with the same name already exists");

                RuleFor(e => e.Name)
                .MaximumLength(100)
                .WithMessage("{PropertyName} must have a maximum of 100 characters");

                RuleFor(e => e.Name)
                .MinimumLength(3)
                .WithMessage("{PropertyName} must have a minimum of 3 characters");

                RuleFor(e => e.Name)
                .Matches(@"^[a-zA-Z0-9\s]*$")
                .WithMessage("{PropertyName} must contain only letters and numbers");
            });

            RuleSet("update", () =>
            {
                RuleFor(e => e.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} can not be empty");
            });
        }
    }
}