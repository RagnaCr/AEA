using Core.Application.Common.Interfaces.Exchanges;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Integrations.Exchanges;
public class ExchangeApiClientFactory : IExchangeApiClientFactory
{
    private readonly IServiceProvider _serviceProvider;

    public ExchangeApiClientFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IExchangeApiClient GetClient(string exchangeName)
    {
        // Получаем ВСЕ реализации IExchangeApiClient
        var clients = _serviceProvider.GetServices<IExchangeApiClient>();
        // Находим нужную по ее свойству ExchangeName
        var client = clients.FirstOrDefault(c => c.ExchangeName.Equals(exchangeName, StringComparison.OrdinalIgnoreCase));

        if (client == null)
        {
            throw new NotSupportedException($"Exchange '{exchangeName}' is not supported.");
        }
        return client;
    }
}