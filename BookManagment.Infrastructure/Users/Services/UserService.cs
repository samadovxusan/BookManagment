using System.Linq.Expressions;
using AutoMapper;
using BookManagment.Application.Users.Models;
using BookManagment.Application.Users.Service;
using BookManagment.Domain.Common.Entities;
using BookManagment.Domain.Entities;
using BookManagment.Persistence.Extensions;
using BookManagment.Persistence.Repositories.Interfaces;
using FluentValidation;

namespace BookManagment.Infrastructure.Users.Services;

public class UserService(IUserRepository userRepository,IMapper mapper,IValidator<UserCretential> validator):IUserService
{
    public IQueryable<User> Get(FilterPagination filterPagination, Expression<Func<User, bool>>? predicate = default)
    {
        return userRepository.Get(predicate);
    }

    public IQueryable<User> Get(UserFilters clientFilter)
    {
        return userRepository.Get().ApplyPagination(clientFilter);
    }

    public ValueTask<User?> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default)
        => userRepository.GetByIdAsync(userId, cancellationToken);

    public async ValueTask<bool> CreateAsync(UserCretential user, CancellationToken cancellationToken = default)
    {
        var validationResult = validator
            .Validate(user,
                options => options.IncludeRuleSets("Registration"));
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var result = await userRepository.CreateAsync(mapper.Map<User>(user), cancellationToken);
        return result is not null;
    }


    public async ValueTask<bool> UpdateAsync(UserDto user, CancellationToken cancellationToken = default)
    {
        var result = await userRepository.UpdateAsync(mapper.Map<User>(user), cancellationToken);
        return result is not null;
        
    }

    public ValueTask<User?> DeleteByIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return userRepository.DeleteByIdAsync(userId, cancellationToken);
    }
}