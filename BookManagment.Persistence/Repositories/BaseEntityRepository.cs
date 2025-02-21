using System.Linq.Expressions;
using BookManagment.Domain.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BookManagment.Persistence.Repositories;

public abstract class EntityRepositoryBase<TEntity, TContext>(
    TContext dbContext)
    where TEntity : class, IEntity where TContext : DbContext
{
    protected TContext DbContext => dbContext;

    protected IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? predicate = default, bool asNoTracking = false)
    {
        var initialQuery = DbContext.Set<TEntity>().Where(entity => true);

        if (predicate is not null)
            initialQuery = initialQuery.Where(predicate);

        if (asNoTracking)
            initialQuery = initialQuery.AsNoTracking();

        return initialQuery;
    }

    protected IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? predicate = default)
    {
        var initialQuery = DbContext.Set<TEntity>().Where(entity => true);

        if (predicate is not null)
            initialQuery = initialQuery.Where(predicate);

        return initialQuery;
    }

    protected async ValueTask<TEntity?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default
    )
    {
        var foundEntity = default(TEntity?);

        var initialQuery = DbContext.Set<TEntity>().AsQueryable();

        foundEntity = await initialQuery.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);

        return foundEntity;
    }

    protected async ValueTask<bool> CheckByIdAsync(Guid entityId, CancellationToken cancellationToken = default)
    {
        var foundEntity = await DbContext.Set<TEntity>()
            .Select(entity => entity.Id)
            .FirstOrDefaultAsync(foundEntityId => foundEntityId == entityId, cancellationToken);

        return foundEntity != Guid.Empty;
    }

    protected async ValueTask<IList<TEntity>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        CancellationToken cancellationToken = default
    )
    {
        var initialQuery = DbContext.Set<TEntity>().Where(entity => ids.Contains(entity.Id));

        return await initialQuery.ToListAsync(cancellationToken: cancellationToken);
    }

    protected async ValueTask<TEntity> CreateAsync(
        TEntity entity,
        CancellationToken cancellationToken = default
    )
    {
        await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    protected async ValueTask<TEntity> UpdateAsync(
        TEntity entity,
        CancellationToken cancellationToken = default
    )
    {
        DbContext.Set<TEntity>().Update(entity);
        await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    protected async ValueTask<TEntity?> DeleteAsync(
        TEntity entity,
        CancellationToken cancellationToken = default
    )
    {
        DbContext.Set<TEntity>().Remove(entity);


        await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    protected async ValueTask<TEntity?> DeleteByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default
    )
    {
        var entity = await DbContext
                         .Set<TEntity>()
                         .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken)
                     ?? throw new InvalidOperationException();

        DbContext.Remove(entity);


        await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    protected async ValueTask<int> UpdateBatchAsync(
        Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> setPropertyCalls,
        Expression<Func<TEntity, bool>>? batchUpdatePredicate = default,
        CancellationToken cancellationToken = default
    )
    {
        var entities = DbContext.Set<TEntity>().AsQueryable();

        if (batchUpdatePredicate is not null)
            entities = entities.Where(batchUpdatePredicate);

        return await entities.ExecuteUpdateAsync(
            setPropertyCalls,
            cancellationToken
        );
    }
}