using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Presentation.Web.Auth;
using System.Net.Http.Json;
using System.Text.Json;

namespace Presentation.Web.Services;

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;
    private readonly AuthenticationStateProvider _authStateProvider;

    public AuthService(HttpClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
        _authStateProvider = authStateProvider;
    }

    public async Task<bool> RegisterAsync(RegisterRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("api/auth/register", request);
        return response.IsSuccessStatusCode;
    }

    public async Task<LoginResult> LoginAsync(LoginRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("api/auth/login", request);
        if (!response.IsSuccessStatusCode)
        {
            return new LoginResult(false, null, "Invalid email or password.");
        }

        var content = await response.Content.ReadAsStringAsync();
        var loginResponse = JsonSerializer.Deserialize<JsonElement>(content);
        var token = loginResponse.GetProperty("token").GetString();

        if (string.IsNullOrEmpty(token))
        {
            return new LoginResult(false, null, "Failed to retrieve token.");
        }

        await _localStorage.SetItemAsStringAsync("authToken", token);
        // Уведомляем систему, что состояние аутентификации изменилось
        await ((CustomAuthStateProvider)_authStateProvider).NotifyUserAuthentication(token);

        return new LoginResult(true, token, null);
    }

    public async Task LogoutAsync()
    {
        await _localStorage.RemoveItemAsync("authToken");
        // Уведомляем систему о выходе
        await ((CustomAuthStateProvider)_authStateProvider).NotifyUserLogout();
    }
}