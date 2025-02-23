using BookManagment.Domain.Common.Entities;
using BookManagment.Domain.Enums;

namespace BookManagment.Domain.Entities;

public class User:AuditableEntity
{
    public string Name { get; set; } = default!;

    public string EmailAddress { get; set; } = default!;

    public string Password { get; set; } = default!;

    public Role Role { get; set; } = Role.User;
}