using System.ComponentModel.DataAnnotations;


namespace Core.Application.Features.Auth.Dtos;
public record LoginRequest(
    [Required, EmailAddress] string Email,
    [Required] string Password
);
