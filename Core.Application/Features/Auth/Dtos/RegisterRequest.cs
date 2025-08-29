using System.ComponentModel.DataAnnotations;

namespace Core.Application.Features.Auth.Dtos;

public record RegisterRequest(
    [Required] string NickName,
    [Required, EmailAddress] string Email,
    [Required] string Password
);
