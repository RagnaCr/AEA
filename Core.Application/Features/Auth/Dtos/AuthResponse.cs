namespace Core.Application.Features.Auth.Dtos;
public record AuthResponse(
    string UserId,
    string NickName,
    string Email,
    string Token
);
