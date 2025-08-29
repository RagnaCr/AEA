using Core.Application.Common.Interfaces.Exchanges;
using Core.Application.Common.Interfaces;
using Core.Domain.Entity;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Net.Http.Json;

namespace Infrastructure.Integrations.Exchanges;

// DTO для ответа при обновлении токена
public record QuestradeTokenResponse(string access_token, string refresh_token, string api_server, int expires_in, string token_type);

public class QuestradeApiClient : IExchangeApiClient
{
    private readonly ILogger<QuestradeApiClient> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IApplicationDbContext _dbContext;
    private readonly IDataProtectionService _dataProtectionService;

    public string ExchangeName => "Questrade";
    private const string TokenUrl = "https://login.questrade.com/oauth2/token";

    // нужны зависимости для работы с HTTP, БД (для обновления токена) и шифрованием
    public QuestradeApiClient(ILogger<QuestradeApiClient> logger, IHttpClientFactory httpClientFactory, IApplicationDbContext dbContext, IDataProtectionService dataProtectionService)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
        _dbContext = dbContext;
        _dataProtectionService = dataProtectionService;
    }

    public async Task<IEnumerable<ExchangeTransaction>> GetTransactionsAsync(ApiConnection connection)
    {
        var session = await GetAuthenticatedSessionAsync(connection);
        if (session == null)
        {
            throw new InvalidOperationException("Failed to authenticate with Questrade.");
        }

        var httpClient = _httpClientFactory.CreateClient();
        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session.access_token);

        // Получаем ID всех счетов пользователя
        var accountsResponse = await httpClient.GetAsync($"{session.api_server}v1/accounts");
        if (!accountsResponse.IsSuccessStatusCode) throw new Exception("Failed to get Questrade accounts.");

        var accountsData = await accountsResponse.Content.ReadFromJsonAsync<JsonDocument>();
        var accounts = accountsData.RootElement.GetProperty("accounts").EnumerateArray();
        var accountIds = accounts.Select(acc => acc.GetProperty("number").GetString()).ToList();

        var allActivities = new List<ExchangeTransaction>();

        foreach (var accountId in accountIds)
        {
            _logger.LogInformation("Fetching activities for Questrade account {AccountId}", accountId);

            // Логика пагинации по дате
            var startDate = connection.LastSuccessfulSync?.Date ?? new DateTime(2015, 10, 1); // Начинаем с даты последней синхронизации или с очень старой даты
            var today = DateTime.UtcNow.Date;

            while (startDate <= today)
            {
                var endDate = startDate.AddDays(29);
                if (endDate > today) endDate = today;

                // startTime - начало дня startDate
                var startOfDay = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0, DateTimeKind.Utc);
                // endTime - самый конец дня endDate
                var endOfDay = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59, 999, DateTimeKind.Utc);

                var startIso = startOfDay.ToString("yyyy-MM-dd'T'HH:mm:ss.ffffff'Z'");
                var endIso = endOfDay.ToString("yyyy-MM-dd'T'HH:mm:ss.ffffff'Z'");

                var url = $"{session.api_server}v1/accounts/{accountId}/activities?startTime={startIso}&endTime={endIso}";
                _logger.LogInformation("Requesting activities from URL: {ActivitiesUrl}", url); // ПОТОМ УДАЛИТЬ

                var activitiesResponse = await httpClient.GetAsync(url);
                if (activitiesResponse.IsSuccessStatusCode)
                {

                    var activitiesJson = await activitiesResponse.Content.ReadAsStringAsync(); // <-- Читаем как строку для отладки
                    _logger.LogInformation("Received successful response for account {AccountId}. JSON Length: {Length}", accountId, activitiesJson.Length);

                    //var activitiesData = await activitiesResponse.Content.ReadFromJsonAsync<JsonDocument>();
                    var activitiesData = JsonDocument.Parse(activitiesJson); // Парсим вручную

                    //var activities = activitiesData.RootElement.GetProperty("activities").EnumerateArray();

                    if (activitiesData.RootElement.TryGetProperty("activities", out var activitiesElement)) // if-else новое
                    {
                        var activities = activitiesElement.EnumerateArray().ToList(); // <-- Материализуем список
                        _logger.LogInformation("Found {Count} activities in the response.", activities.Count);

                        // Преобразуем в наш универсальный формат
                        foreach (var activity in activities)
                        {
                            // Создаем уникальный ID, т.к. у Questrade его нет. Комбинация даты, типа и суммы.
                            var transactionDate = activity.GetProperty("transactionDate").GetDateTime().ToUniversalTime();
                            var type = activity.GetProperty("type").GetString();
                            var netAmount = activity.GetProperty("netAmount").GetDecimal();

                            // Используем УНИФИЦИРОВАННЫЙ формат ID
                            var transactionId = $"{transactionDate:o}-{type}-{netAmount}";

                            allActivities.Add(new ExchangeTransaction(
                                transactionId,
                                transactionDate,
                                type,
                                activity.GetProperty("description").GetString(),
                                activity.Clone()
                            ));
                        }
                    }
                    else // новое
                    {
                        _logger.LogWarning("Response JSON does not contain 'activities' property. Response: {JsonResponse}", activitiesJson);
                    }
                }
                else // новое
                {
                    var errorContent = await activitiesResponse.Content.ReadAsStringAsync();
                    _logger.LogError("Request to Questrade API failed with status {StatusCode}. Response: {ErrorResponse}", activitiesResponse.StatusCode, errorContent);
                }

                startDate = endDate.AddDays(1);
                await Task.Delay(500); // Небольшая задержка
            }
        }
        return allActivities;
    }

    private async Task<QuestradeTokenResponse?> GetAuthenticatedSessionAsync(ApiConnection connection)
    {
        var refreshToken = _dataProtectionService.Decrypt(connection.EncryptedKey1);

        _logger.LogInformation("-> Refreshing Questrade access token...");
        var httpClient = _httpClientFactory.CreateClient();
        var response = await httpClient.PostAsync(TokenUrl, new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("grant_type", "refresh_token"),
            new KeyValuePair<string, string>("refresh_token", refreshToken)
        }));

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            _logger.LogError("!!! Questrade token refresh failed: {Error}", error);
            connection.MarkAsAuthError(error);
            await _dbContext.SaveChangesAsync(new CancellationToken());
            return null;
        }

        var sessionData = await response.Content.ReadFromJsonAsync<QuestradeTokenResponse>();
        if (sessionData == null) return null;

        // --- САМОЕ ВАЖНОЕ ОБНОВЛЕНИЕ REFRESH TOKEN В БАЗЕ ---
        if (sessionData.refresh_token != refreshToken)
        {
            _logger.LogInformation("--> Questrade returned a new refresh token. Updating database...");
            var newEncryptedToken = _dataProtectionService.Encrypt(sessionData.refresh_token);
            connection.UpdateRefreshToken(newEncryptedToken);
            // Сохраняем сразу, чтобы не потерять новый токен при сбое
            await _dbContext.SaveChangesAsync(new CancellationToken());
        }

        return sessionData;
    }
}