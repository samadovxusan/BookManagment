using System.Linq.Expressions;
using BookManagment.Domain.Entities;

namespace BookManagment.Persistence.Repositories.Interfaces;

public interface IUserRepository
{
    IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default);

    ValueTask<User?> GetByIdAsync(Guid clientId,
        CancellationToken cancellationToken = default);

    ValueTask<User> CreateAsync(User user,
        CancellationToken cancellationToken = default);


    ValueTask<User> UpdateAsync(User user,
        CancellationToken cancellationToken = default);

    ValueTask<User?> DeleteByIdAsync(Guid clientId,
        CancellationToken cancellationToken = default);
}