using BookManagment.Domain.Common.Entities;

namespace BookManagment.Domain.Entities;

public class User:AuditableEntity
{
    public string Name { get; set; } = default!;

    public string EmailAddress { get; set; } = default!;

    public string Password { get; set; } = default!;
}