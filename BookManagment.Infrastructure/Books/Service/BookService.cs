using AutoMapper;
using BookManagment.Application.Books.Models;
using BookManagment.Application.Books.Service;
using BookManagment.Domain.Entities;
using BookManagment.Persistence.Repositories.Interfaces;
using FluentValidation;

namespace BookManagment.Infrastructure.Books.Service;

public class BookService(IBookRepository repository,IValidator<BookDto> validator, IMapper mapper):IBookService
{
    public ValueTask<Book?> GetBookDetailsAsync(Guid id, CancellationToken cancellationToken = default)
        => repository.GetBookByIdAsync(id, cancellationToken: cancellationToken);

    public Task<List<Book>?> GetAllBooks(CancellationToken cancellationToken = default)
    {
        return repository.GetAllBooks();
    }


    public ValueTask<IEnumerable<string>> GetPopularBooksAsync(int page, int pageSize,
        CancellationToken cancellationToken = default)
        => repository.GetPopularBooksAsync(page, pageSize, cancellationToken);

    public async ValueTask<Book?> GetBookByTitleAsync(string title, CancellationToken cancellationToken = default)
    {
        return await repository.GetBookByTitleAsync(title, cancellationToken);
    }
    public async ValueTask<bool> AddBookAsync(BookDto book, CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(book, options =>
            options.IncludeRuleSets("Create")); 

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);


        var result = await repository.CreateAsync(mapper.Map<Book>(book), cancellationToken);
        return result is not null;
    }



    public async ValueTask<bool> UpdateBookAsync(BookDto book, CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(book, options =>
            options.IncludeRuleSets("Registration")); 

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var result = await repository.UpdateAsync(mapper.Map<Book>(book), cancellationToken);
        return result is not null;
    }
    

    public ValueTask<bool> SoftDeleteBookAsync(Guid id, CancellationToken cancellationToken = default)
        => repository.SoftDeleteAsync(id, cancellationToken);
}
