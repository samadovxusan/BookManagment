using BookManagment.Application.Books.Models;
using BookManagment.Application.Books.Service;
using BookManagment.Domain.Common.Entities;
using Microsoft.Extensions.Options;

namespace BookManagment.Infrastructure.Books.Validators;

using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

public class BookValidator : AbstractValidator<BookDto>
{
    public BookValidator(IOptions<ValidationSettings> validationSettings)
    {
        var validationSettingsValue = validationSettings.Value;

        RuleSet("Registration", () =>
        {
            RuleFor(client => client.Title)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(64)
                .Matches(validationSettingsValue.NameRegexPattern);

            RuleFor(client => client.AuthorName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(128)
                .Matches(validationSettingsValue.NameRegexPattern);
        });
    }
}