using BookManagment.Application.Auth.Services;
using BookManagment.Application.Users.Models;
using BookManagment.Domain.Common.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controller;
[Controller]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("Register")]
    public async Task<IActionResult> Register(UserCretential register)
    {

        var result = await authService.Register(register);
        return Ok(result);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(Login login)
    {
        var result = await authService.Login(login);
        return Ok(result);
    }
}