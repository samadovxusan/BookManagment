using BookManagment.Domain.Entities;
using BookManagment.Persistence.DbContexs;
using BookManagment.Persistence.Extensions;
using BookManagment.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookManagment.Persistence.Repositories;

public class BookRepository(AppDbContext _context) : IBookRepository
{
    public async Task<Book?> GetBookByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var book = await _context.Books.FindAsync(new object?[] { id }, cancellationToken);
        if (book != null) book.ViewsCount++;
        await _context.SaveChangesAsync(cancellationToken);
        return book;
    }

    public ValueTask<Book?> GetBookByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<Book?> GetBookByTitleAsync(string title, CancellationToken cancellationToken = default)
    {
        return await _context.Books.FirstOrDefaultAsync(b => b.Title == title && !b.IsDeleted, cancellationToken);
    }

    public Task<List<Book>> GetAllBooks(CancellationToken cancellationToken = default)
    {
        return  _context.Books.ToListAsync();
    }

    public async ValueTask<IEnumerable<string>> GetPopularBooksAsync(int page, int pageSize,
        CancellationToken cancellationToken = default)
    {
        return await _context.Books
            .Where(b => !b.IsDeleted)
            .OrderByDescending(b => b.PopularityScore)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(b => b.Title)
            .ToListAsync(cancellationToken);
    }

    public async ValueTask<IEnumerable<Book>> GetAllBooksAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Books.Where(b => !b.IsDeleted).ToListAsync(cancellationToken);
    }

    public async ValueTask<Book> CreateAsync(Book book, CancellationToken cancellationToken = default)
    {
        if (await GetBookByTitleAsync(book.Title, cancellationToken) != null)
            throw new InvalidOperationException("A book with the same title already exists.");

        book.PublicationYear =  (int)((book.PublicationYear * 0.5) + ((DateTime.UtcNow.Year - book.PublicationYear) * 2));
        

        _context.Books.Add(book);
        await _context.SaveChangesAsync(cancellationToken);
        return book;
    }

    public async ValueTask<Book> UpdateAsync(Book book, CancellationToken cancellationToken = default)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync(cancellationToken);
        return book;
    }

    public async ValueTask<bool> SoftDeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var book = await _context.Books.FindAsync(new object?[] { id }, cancellationToken);
        if (book == null) return false;

        book.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async ValueTask<bool> BulkSoftDeleteAsync(List<Guid> bookIds, CancellationToken cancellationToken = default)
    {
        var books = await _context.Books.Where(b => bookIds.Contains(b.Id) && !b.IsDeleted)
            .ToListAsync(cancellationToken);
        if (!books.Any()) return false;

        foreach (var book in books) book.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}