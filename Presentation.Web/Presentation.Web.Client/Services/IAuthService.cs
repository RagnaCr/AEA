namespace Presentation.Web.Services;

// DTO для запросов (можно вынести в общий проект, но пока оставим здесь)
public record RegisterRequest(string NickName, string Email, string Password);
public record LoginRequest(string Email, string Password);
public record LoginResult(bool IsSuccess, string? Token, string? ErrorMessage);

public interface IAuthService
{
    Task<bool> RegisterAsync(RegisterRequest request);
    Task<LoginResult> LoginAsync(LoginRequest request);
    Task LogoutAsync();
}