using DEPLOY.BookStore.Domain.Aggregates.Book.Interfaces.Repositories;
using DEPLOY.BookStore.Domain.Aggregates.BookPublisher.Interfaces.Repositories;
using DEPLOY.BookStore.Domain.Aggregates.BookPublisher.Validators;
using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace DEPLOY.BookStore.Domain.Aggregates.Book.Validators
{
    [ExcludeFromCodeCoverage]
    public class BookValidator : AbstractValidator<Domain.Aggregates.Book.Entities.Book>
    {
        public BookValidator()
        {
            RuleSet("new", () =>
            {
                RuleFor(e => e.Title)
                .NotEmpty()
                .WithMessage("{PropertyName} can not be empty");

                RuleFor(e => e.Title)
                .MaximumLength(100)
                .WithMessage("{PropertyName} must have a maximum of 100 characters");

                RuleFor(e => e.Title)
                .MinimumLength(3)
                .WithMessage("{PropertyName} must have a minimum of 3 characters");

                RuleFor(e => e.LauchDate)
                .NotEmpty()
                .WithMessage("{PropertyName} can not be empty");

                RuleFor(e => e.Author)
                .NotEmpty()
                .WithMessage("{PropertyName} can not be empty");

                RuleFor(e => e.Author)
                .MaximumLength(100)
                .WithMessage("{PropertyName} must have a maximum of 100 characters");

                RuleFor(e => e.Author)
                .MinimumLength(3)
                .WithMessage("{PropertyName} must have a minimum of 3 characters");

                RuleFor(e => e.Value)
                .NotEmpty()
                .WithMessage("{PropertyName} can not be empty");

                RuleFor(e => e.Value)
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be greater than 0");

                RuleFor(e => e.BookPublisher)
                .SetValidator(new BookPublisherValidator());
            });

            RuleSet("update", () =>
            {
                RuleFor(e => e.Title)
                .NotEmpty()
                .WithMessage("{PropertyName} can not be empty");

                RuleFor(e => e.BookPublisher)
                .SetValidator(new BookPublisherValidator());
            });
        }
    }
}