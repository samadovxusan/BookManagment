namespace BookManagment.Domain.Common.Entities;

public record ValidationSettings
{
    public string NameRegexPattern { get; init; } = default!;

    public string EmailRegexPattern { get; init; } = default!;
}