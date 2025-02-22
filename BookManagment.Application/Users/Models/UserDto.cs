namespace BookManagment.Application.Users.Models;

public class UserDto
{
    public string Name { get; set; } = default!;

    public string EmailAddress { get; set; } = default!;

    public string Password { get; set; } = default!;
}