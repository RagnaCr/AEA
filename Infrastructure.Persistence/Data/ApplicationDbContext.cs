using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Core.Domain.Entity;
using Core.Application.Common.Interfaces;

namespace Infrastructure.Persistence.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Здесь мы явно определяем DbSet для каждой нашей сущности.
        // EF Core найдет DbSet<User> в базовом IdentityDbContext.
        public DbSet<Asset> Assets => Set<Asset>();
        public DbSet<Portfolio> Portfolios => Set<Portfolio>();
        public DbSet<Operation> Operations => Set<Operation>();
        public DbSet<TransactionLeg> TransactionLegs => Set<TransactionLeg>();
        public DbSet<ApiConnection> ApiConnections => Set<ApiConnection>();
        public DbSet<PortfolioApiConnection> PortfolioApiConnections => Set<PortfolioApiConnection>();
        public DbSet<PortfolioDailySnapshot> PortfolioDailySnapshots => Set<PortfolioDailySnapshot>();
        public DbSet<TaxReport> TaxReports => Set<TaxReport>();
        public DbSet<TaxReportPortfolio> TaxReportPortfolios => Set<TaxReportPortfolio>();
        public DbSet<TaxableEvent> TaxableEvents => Set<TaxableEvent>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Этот метод просканирует всю сборку (наш проект Infrastructure.Persistence)
            // на наличие классов конфигурации и применит их все сразу.
            // Это гораздо чище, чем писать всю конфигурацию прямо здесь.
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
