using Core.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Data.Configurations;
public class TaxableEventConfiguration : IEntityTypeConfiguration<TaxableEvent>
{
    public void Configure(EntityTypeBuilder<TaxableEvent> builder)
    {
        builder.HasKey(te => te.Id);

        builder.Property(te => te.QuantityDisposed).HasColumnType("decimal(18, 8)");
        builder.Property(te => te.Proceeds).HasColumnType("decimal(18, 2)");
        builder.Property(te => te.CostBasis).HasColumnType("decimal(18, 2)");

        // Связь с исходной операцией
        builder.HasOne<Operation>()
            .WithMany()
            .HasForeignKey(te => te.SourceOperationId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь с ассетом
        builder.HasOne<Asset>()
            .WithMany()
            .HasForeignKey(te => te.AssetId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}