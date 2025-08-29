using Core.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class TaxReportConfiguration : IEntityTypeConfiguration<TaxReport>
{
    public void Configure(EntityTypeBuilder<TaxReport> builder)
    {
        builder.HasKey(tr => tr.Id);

        builder.Property(tr => tr.Name).IsRequired().HasMaxLength(150);
        builder.Property(tr => tr.JurisdictionCountryCode).IsRequired().HasMaxLength(2);

        // Связь с пользователем
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(tr => tr.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        // Связь с TaxableEvent
        builder.HasMany(tr => tr.TaxableEvents)
            .WithOne()
            .HasForeignKey(te => te.TaxReportId)
            .OnDelete(DeleteBehavior.Cascade); // Удалять события при удалении отчета
    }
}