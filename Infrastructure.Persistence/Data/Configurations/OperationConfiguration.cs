using Core.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class OperationConfiguration : IEntityTypeConfiguration<Operation>
{
    public void Configure(EntityTypeBuilder<Operation> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.SourceOperationId).HasMaxLength(255);

        builder.Property(o => o.Type)
        .HasConversion<string>()
        .HasMaxLength(50);

        builder.Property(o => o.Source)
        .HasConversion<string>()
        .HasMaxLength(50);

        builder.HasIndex(o => new { o.Source, o.SourceOperationId });

        // Связь с TransactionLeg (один-ко-многим)
        // Говорим, что коллекция 'Legs' в Operation связана
        // с навигационным свойством 'Operation' в TransactionLeg.
        // EF Core сам поймет, что внешний ключ - это OperationId.
        builder.HasMany(o => o.Legs)
            .WithOne(l => l.Operation) // <-- Указываем обратное навигационное свойство
            .HasForeignKey(l => l.OperationId) // Явно указываем ключ для надежности
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
