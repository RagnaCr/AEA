using Core.Application.Common.Interfaces.Exchanges;
using Core.Application.Common.Interfaces;
using Core.Domain.Enums;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Core.Application.Features.Operations.Commands.ProcessExchangeTransactions;

namespace Infrastructure.Integrations.BackgroundJobs;
public class ApiDataSyncJob : BackgroundService
{
    private readonly ILogger<ApiDataSyncJob> _logger;
    private readonly IServiceProvider _serviceProvider;

    public ApiDataSyncJob(ILogger<ApiDataSyncJob> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Запускаем периодически, например, каждые 15 минут
        using var timer = new PeriodicTimer(TimeSpan.FromMinutes(15));
        //using var timer = new PeriodicTimer(TimeSpan.FromMilliseconds(10000));

        while (await timer.WaitForNextTickAsync(stoppingToken))
        {
            _logger.LogInformation("Starting API data sync job...");
            using var scope = _serviceProvider.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
            var protectionService = scope.ServiceProvider.GetRequiredService<IDataProtectionService>();
            var clientFactory = scope.ServiceProvider.GetRequiredService<IExchangeApiClientFactory>();
            // понадобится MediatR для сохранения операций
            var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

            var connectionsToSync = await dbContext.ApiConnections
                .Where(c => c.Status != ApiConnectionStatus.Disabled)
                .ToListAsync(stoppingToken);

            foreach (var connection in connectionsToSync)
            {
                try
                {
                    var apiClient = clientFactory.GetClient(connection.ExchangeName);

                    var transactions = await apiClient.GetTransactionsAsync(connection);

                    if (transactions.Any())
                    {
                        var command = new ProcessExchangeTransactionsCommand(connection.Id, connection.UserId, transactions);
                        await mediator.Send(command, stoppingToken);
                        connection.MarkAsHealthy();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to sync data for connection {ConnectionName}", connection.ConnectionName);
                    connection.MarkAsFailing(ex.Message);
                }
                await dbContext.SaveChangesAsync(stoppingToken);
            }
        }
    }
}