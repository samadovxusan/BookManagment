using AutoMapper;
using BookManagment.Application.Auth.Services;
using BookManagment.Application.Users.Models;
using BookManagment.Domain.Common.Entities;
using BookManagment.Domain.Entities;
using BookManagment.Persistence.DbContexs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookManagment.Infrastructure.Auth.Services;

public class AuthService(AppDbContext dbContext, IMapper mapper, IConfiguration configuration): IAuthService
{
    public async  ValueTask<bool> Register(UserCretential register)
    {
        try
        {
            var user = mapper.Map<User>(register);
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async ValueTask<LoginDto> Login(Login login)
    {
        var token = new LoginDto();
        var newUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Password == login.Password && x.EmailAddress == login.Email);
        if(newUser == null)
        {
            token.Succes = false;
            return token;
        }
        var jwtToken = new IdentityTokenGeneratorService(configuration);
        token.Token = await jwtToken.GenerateToken(newUser); 
        return token;
    }
}