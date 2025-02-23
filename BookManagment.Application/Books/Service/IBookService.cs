using BookManagment.Application.Books.Models;
using BookManagment.Domain.Entities;

namespace BookManagment.Application.Books.Service;

public interface IBookService
{
    public ValueTask<Book?> GetBookDetailsAsync(Guid id, CancellationToken cancellationToken = default);
    
    public Task<List<Book>?> GetAllBooks(CancellationToken cancellationToken = default);
    
    public ValueTask<IEnumerable<string>> GetPopularBooksAsync(int page, int pageSize,
        CancellationToken cancellationToken = default);

    ValueTask<Book?> GetBookByTitleAsync(string title, CancellationToken cancellationToken = default);
    
    public ValueTask<bool> AddBookAsync(BookDto book, CancellationToken cancellationToken = default);

    public ValueTask<bool> UpdateBookAsync(BookDto book, CancellationToken cancellationToken = default);
    public ValueTask<bool> SoftDeleteBookAsync(Guid id, CancellationToken cancellationToken = default);
}