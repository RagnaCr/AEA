using Core.Application.Common.Interfaces;
using Core.Application.Features.Portfolios.Commands.CreateDailySnapshot;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Integrations.BackgroundJobs;

public class PortfolioSnapshotJob : BackgroundService
{
    private readonly ILogger<PortfolioSnapshotJob> _logger;
    private readonly IServiceProvider _serviceProvider;

    public PortfolioSnapshotJob(ILogger<PortfolioSnapshotJob> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Portfolio Snapshot Job is starting.");

        while (!stoppingToken.IsCancellationRequested)
        {
            var now = DateTime.UtcNow;
            var nextRunTime = now.Date.AddDays(1).AddHours(2); // Запускаем каждый день в 2 часа ночи UTC
            var delay = nextRunTime - now;

            if (delay.TotalSeconds <= 0)
            {
                // Если уже 2 часа ночи прошли, то следующий запуск завтра
                delay = delay.Add(TimeSpan.FromDays(1));
            }

            _logger.LogInformation("Next portfolio snapshot run scheduled in {Delay}", delay);
            await Task.Delay(delay, stoppingToken);

            if (stoppingToken.IsCancellationRequested) break;

            _logger.LogInformation("Starting daily portfolio snapshot calculation...");

            try
            {
                // Создаем Scoped-окружение для получения сервисов
                using var scope = _serviceProvider.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
                var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

                var portfolioIds = await dbContext.Portfolios.Select(p => p.Id).ToListAsync(stoppingToken);

                foreach (var portfolioId in portfolioIds)
                {
                    if (stoppingToken.IsCancellationRequested) break;

                    _logger.LogDebug("Calculating snapshot for portfolio {PortfolioId}", portfolioId);
                    var command = new CreateDailySnapshotCommand
                    {
                        PortfolioId = portfolioId,
                        Date = DateTime.UtcNow.Date.AddDays(-1) // Считаем снэпшот за вчерашний день
                    };
                    await mediator.Send(command, stoppingToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during portfolio snapshot calculation.");
            }

            _logger.LogInformation("Daily portfolio snapshot calculation finished.");
        }
    }
}