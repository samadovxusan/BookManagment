using System.Security.Claims;
using BookManagment.Domain.Entities;

namespace BookManagment.Application.Auth.Services;

public interface IIdentityTokenGeneratorService
{
    Task<string> GenerateToken(User user);
    Task<string> GenerateToken(IEnumerable<Claim> additionalClaims);
    
}