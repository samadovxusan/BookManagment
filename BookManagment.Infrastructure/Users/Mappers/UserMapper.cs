using AutoMapper;
using BookManagment.Application.Users.Models;
using BookManagment.Domain.Entities;

namespace BookManagment.Infrastructure.Users.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, UserCretential>().ReverseMap();
    }
}