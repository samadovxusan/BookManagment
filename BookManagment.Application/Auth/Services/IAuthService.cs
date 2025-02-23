using BookManagment.Application.Users.Models;
using BookManagment.Domain.Common.Entities;

namespace BookManagment.Application.Auth.Services;

public interface IAuthService
{
    ValueTask<Boolean> Register (UserCretential register);
    ValueTask<LoginDto> Login (Login login);
}