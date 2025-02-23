namespace BookManagment.Domain.Common.Entities;

public class LoginDto
{
    public string Token { get; set; } = string.Empty;
    public bool Succes { get; set; } = true;
}