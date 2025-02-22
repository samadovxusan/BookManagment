using System.Linq.Expressions;
using BookManagment.Application.Users.Models;
using BookManagment.Domain.Common.Entities;
using BookManagment.Domain.Entities;

namespace BookManagment.Application.Users.Service;

public interface IUserService
{
    IQueryable<User> Get(FilterPagination filterPagination, Expression<Func<User, bool>>? predicate = default);

    IQueryable<User> Get(UserFilters clientFilter);

    ValueTask<User?> GetByIdAsync(Guid userId,
        CancellationToken cancellationToken = default);

    ValueTask<bool> CreateAsync(UserCretential user,
        CancellationToken cancellationToken = default);

    ValueTask<bool> UpdateAsync(UserDto user,
        CancellationToken cancellationToken = default);

    ValueTask<User?> DeleteByIdAsync(Guid userId,
        CancellationToken cancellationToken = default);
}