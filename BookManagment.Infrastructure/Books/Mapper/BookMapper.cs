using AutoMapper;
using BookManagment.Application.Books.Models;
using BookManagment.Domain.Entities;

namespace BookManagment.Infrastructure.Books.Mapper;

public class BookMapper:Profile
{
    public BookMapper()
    {
        CreateMap<Book, BookDto>().ReverseMap();
    }
}