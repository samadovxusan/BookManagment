﻿namespace BookManagment.Domain.Common.Entities;

public class Login
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}