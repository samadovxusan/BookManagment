using BookManagment.Domain.Enums;

namespace BookManagment.Domain.Common.Entities;

public class Register
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Phone { get; set; }
    public Role Role { get; set; }
}