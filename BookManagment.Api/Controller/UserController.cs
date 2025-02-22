using BookManagment.Application.Users.Models;
using BookManagment.Application.Users.Service;
using BookManagment.Domain.Common.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controller;

[Controller]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get(FilterPagination filterPagination)
    {
        var result = userService.Get(filterPagination);
        return Ok(result);
    }

    [HttpGet("{userId:guid}")]
    public async ValueTask<IActionResult> Get(Guid userId)
    {
        var result = await userService.GetByIdAsync(userId);
        return Ok(result);
    }

    [HttpPost]
    public async ValueTask<IActionResult> Post(UserCretential user)
    {
        var result = await userService.CreateAsync(user);
        return Ok(result);
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update(UserDto user)
    {
        var result = await userService.UpdateAsync(user);
        return Ok(result);
    }

    [HttpDelete("{usertId:guid}")]
    public async ValueTask<IActionResult> Delte(Guid userId)
    {
        var result = await userService.DeleteByIdAsync(userId);
        return Ok(result);
    }
}