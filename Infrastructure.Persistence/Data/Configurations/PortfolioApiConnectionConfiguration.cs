using Core.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Data.Configurations;
public class PortfolioApiConnectionConfiguration : IEntityTypeConfiguration<PortfolioApiConnection>
{
    public void Configure(EntityTypeBuilder<PortfolioApiConnection> builder)
    {
        // Вот здесь определяется составной ключ.
        // Если этой строки нет или она закомментирована, будет ошибка.
        builder.HasKey(pac => new { pac.PortfolioId, pac.ApiConnectionId });

        // ... остальные настройки связей ...
        builder.HasOne(pac => pac.Portfolio)
            .WithMany(p => p.ApiConnections)
            .HasForeignKey(pac => pac.PortfolioId);

        builder.HasOne(pac => pac.ApiConnection)
            .WithMany()
            .HasForeignKey(pac => pac.ApiConnectionId);
    }
}