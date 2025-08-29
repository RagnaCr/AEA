using Core.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Data.Configurations;

public class TaxReportPortfolioConfiguration : IEntityTypeConfiguration<TaxReportPortfolio>
{
    public void Configure(EntityTypeBuilder<TaxReportPortfolio> builder)
    {
        builder.HasKey(trp => new { trp.TaxReportId, trp.PortfolioId });

        builder.HasOne<TaxReport>()
            .WithMany(tr => tr.IncludedPortfolios)
            .HasForeignKey(trp => trp.TaxReportId);

        builder.HasOne<Portfolio>()
            .WithMany()
            .HasForeignKey(trp => trp.PortfolioId);
    }
}
