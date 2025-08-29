using Core.Domain.Enums;

namespace Core.Domain.Entity;
/// <summary>
/// ApiConnection класс который является ссылкой для портфолио 
/// но так же принадлежит пользователю чей апи был добавлен в систему
/// </summary>
public class ApiConnection
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; } // Принадлежит пользователю
    public string ConnectionName { get; private set; }
    public string ExchangeName { get; private set; }
    public string EncryptedKey1 { get; private set; }
    public string? EncryptedKey2 { get; private set; }

    public ApiConnectionStatus Status { get; private set; }
    public DateTime? LastSuccessfulSync { get; private set; }
    public string? LastErrorMessage { get; private set; }

    private ApiConnection() { }

    public ApiConnection(Guid userId, string connectionName, string exchangeName, string encryptedKey1, string? encryptedKey2)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        ConnectionName = connectionName;
        ExchangeName = exchangeName;
        EncryptedKey1 = encryptedKey1;
        EncryptedKey2 = encryptedKey2;
    }

    public void UpdateRefreshToken(string newEncryptedRefreshToken)
    {
        EncryptedKey1 = newEncryptedRefreshToken;
    }
    public void UpdateDetails(string newName, string newEncryptedKey1, string? newEncryptedKey2)
    {
        ConnectionName = newName;
        EncryptedKey1 = newEncryptedKey1;
        EncryptedKey2 = newEncryptedKey2;
    }

    public void ResetStatus()
    {
        Status = ApiConnectionStatus.Unknown;
        LastErrorMessage = null;
        LastSuccessfulSync = null;
    }

    public void MarkAsHealthy()
    {
        Status = ApiConnectionStatus.Healthy;
        LastSuccessfulSync = DateTime.UtcNow;
        LastErrorMessage = null;
    }

    public void MarkAsFailing(string errorMessage)
    {
        Status = ApiConnectionStatus.Failing;
        LastErrorMessage = errorMessage;
    }

    public void MarkAsAuthError(string errorMessage)
    {
        Status = ApiConnectionStatus.AuthError;
        LastErrorMessage = errorMessage;
    }

    public void Disable()
    {
        Status = ApiConnectionStatus.Disabled;
    }
}
