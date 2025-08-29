using Core.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Core.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<Asset> Assets { get; }
    DbSet<Portfolio> Portfolios { get; }
    DbSet<Operation> Operations { get; }
    DbSet<TransactionLeg> TransactionLegs { get; }
    DbSet<ApiConnection> ApiConnections { get; }
    DbSet<PortfolioApiConnection> PortfolioApiConnections { get; }
    DbSet<PortfolioDailySnapshot> PortfolioDailySnapshots { get; }
    DbSet<TaxReport> TaxReports { get; }
    DbSet<TaxReportPortfolio> TaxReportPortfolios { get; }
    DbSet<TaxableEvent> TaxableEvents { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
