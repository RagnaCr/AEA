using Core.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Data.Configurations;
public class TransactionLegConfiguration : IEntityTypeConfiguration<TransactionLeg>
{
    public void Configure(EntityTypeBuilder<TransactionLeg> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Quantity).HasColumnType("decimal(18, 8)");
        builder.Property(l => l.PricePerUnit).HasColumnType("decimal(18, 8)");

        builder.Property(o => o.Type)
            .HasConversion<string>()
            .HasMaxLength(50);

        // Связь с основным ассетом
        // Говорим, что навигационное свойство 'Asset' связано с внешним ключом 'AssetId'
        builder.HasOne(l => l.Asset) // <-- Указываем навигационное свойство
            .WithMany()
            .HasForeignKey(l => l.AssetId) // <-- Указываем его ключ
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        // Связь с валютой цены (может быть nullable)
        // Говорим, что навигационное свойство 'PriceCurrency' связано с внешним ключом 'PriceCurrencyId'
        builder.HasOne(l => l.PriceCurrency) // <-- Указываем ВТОРОЕ навигационное свойство
            .WithMany()
            .HasForeignKey(l => l.PriceCurrencyId) // <-- Указываем его ключ
            .OnDelete(DeleteBehavior.Restrict);

    }
}
