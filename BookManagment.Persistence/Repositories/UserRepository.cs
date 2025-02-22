using System.Linq.Expressions;
using BookManagment.Domain.Entities;
using BookManagment.Persistence.DbContexs;
using BookManagment.Persistence.Repositories.Interfaces;

namespace BookManagment.Persistence.Repositories;

public class UserRepository(AppDbContext appDbContext):EntityRepositoryBase<User,AppDbContext>(appDbContext),IUserRepository
{
    public new IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default)
        => base.Get(predicate);

    public new ValueTask<User?> GetByIdAsync(Guid clientId, CancellationToken cancellationToken = default)
        => base.GetByIdAsync(clientId, cancellationToken);

    public new ValueTask<User> CreateAsync(User user, CancellationToken cancellationToken = default)
        => base.CreateAsync(user, cancellationToken);

    public new ValueTask<User> UpdateAsync(User user, CancellationToken cancellationToken = default)
        => base.UpdateAsync(user, cancellationToken);

    public new ValueTask<User?> DeleteByIdAsync(Guid clientId, CancellationToken cancellationToken = default)
        => base.DeleteByIdAsync(clientId, cancellationToken);
}