using Core.Application.Common.Interfaces;
using Microsoft.AspNetCore.DataProtection;

namespace Infrastructure.Integrations.Services;

public class DataProtectionService : IDataProtectionService
{
    private readonly IDataProtector _protector;

    // Мы получаем IDataProtectionProvider и создаем из него "защитник" с уникальной целью.
    // Это гарантирует, что ключи, зашифрованные для "ApiKeys",
    // не могут быть расшифрованы с другим "защитником".
    public DataProtectionService(IDataProtectionProvider provider)
    {
        _protector = provider.CreateProtector("Aggregator.ApiKeys.v1");
    }

    public string Encrypt(string plainText)
    {
        return _protector.Protect(plainText);
    }

    public string Decrypt(string cipherText)
    {
        return _protector.Unprotect(cipherText);
    }
}