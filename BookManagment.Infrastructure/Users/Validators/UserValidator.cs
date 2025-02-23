using BookManagment.Application.Users.Models;
using BookManagment.Domain.Common.Entities;
using BookManagment.Domain.Entities;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace BookManagment.Infrastructure.Users.Validators;

public class UserValidator : AbstractValidator<UserCretential>
{
    public UserValidator(IOptions<ValidationSettings> validationSettings)
    {
        var validationSettingsValue = validationSettings.Value;

        RuleSet("Registration", () =>
        {
            RuleFor(client => client.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(64)
                .Matches(validationSettingsValue.NameRegexPattern);

            RuleFor(client => client.EmailAddress)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(128)
                .Matches(validationSettingsValue.EmailRegexPattern);

            RuleFor(client => client.Password)
                .NotEmpty();
        });
    }
}