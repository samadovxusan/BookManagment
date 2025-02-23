using BookManagment.Application.Books.Models;
using BookManagment.Application.Books.Service;
using BookManagment.Application.Users.Models;
using BookManagment.Domain.Common.Entities;
using BookManagment.Persistence.DbContexs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controller;
[Controller]
[Route("api/[controller]")]
[Authorize]
public class BookController(IBookService service,AppDbContext appDbContext ): ControllerBase
{
    
    [HttpGet("page, pagesize")]
    public async ValueTask<IActionResult> Get(int page,int pageSize)
    {
        var result = service.GetPopularBooksAsync(page,pageSize);
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> Get()
    {
        var result = await appDbContext.Books.ToListAsync();
        return Ok(result);
    }

    [HttpGet("{bookId:guid}")]
    public async ValueTask<IActionResult> Get(Guid bookId)
    {
        var result = await service.GetBookDetailsAsync(bookId);
        return Ok(result);
    }

    [HttpPost]
    public async ValueTask<IActionResult> Post(BookDto bookDto)
    {
        var result = await service.AddBookAsync(bookDto);
        return Ok(result);
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update(BookDto bookDto)
    {
        var result = await service.UpdateBookAsync(bookDto);
        return Ok(result);
    }

    [HttpDelete("{bookId:guid}")]
    public async ValueTask<IActionResult> Delete(Guid bookId)
    {
        var result = await service.SoftDeleteBookAsync(bookId);
        return Ok(result);
    }
    
}