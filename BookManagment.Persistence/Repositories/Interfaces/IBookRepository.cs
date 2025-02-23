using BookManagment.Domain.Entities;

namespace BookManagment.Persistence.Repositories.Interfaces;

public interface IBookRepository
{
    ValueTask<Book?> GetBookByIdAsync(Guid id, CancellationToken cancellationToken = default);
    ValueTask<Book?> GetBookByTitleAsync(string title, CancellationToken cancellationToken = default);
    
    Task<List<Book>> GetAllBooks(CancellationToken cancellationToken = default);
    ValueTask<IEnumerable<string>> GetPopularBooksAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    ValueTask<IEnumerable<Book>> GetAllBooksAsync(CancellationToken cancellationToken = default);
    ValueTask<Book> CreateAsync(Book book, CancellationToken cancellationToken = default);
    ValueTask<Book> UpdateAsync(Book book, CancellationToken cancellationToken = default);
    ValueTask<bool> SoftDeleteAsync(Guid id, CancellationToken cancellationToken = default);
    ValueTask<bool> BulkSoftDeleteAsync(List<Guid> bookIds, CancellationToken cancellationToken = default);
}