﻿namespace Clinica.Application.Common.Interfaces.Dtos
{
    public record SignInDto
    {
        public required string Email { get; set; }

        public required string Password { get; set; }
    }
}