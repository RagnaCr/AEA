using Core.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Data.Configurations;
public class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
{
    public void Configure(EntityTypeBuilder<Portfolio> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        // Связь с User (один-ко-многим)
        builder.HasOne<User>() // Мы не указываем навигационное свойство в User, поэтому тип <User>
            .WithMany(u => u.Portfolios) // Но у User есть свойство Portfolios
            .HasForeignKey(p => p.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade); // Удалить портфели при удалении пользователя

        // Связь с Operation (один-ко-многим)
        builder.HasMany(p => p.Operations)
            .WithOne() // У Operation нет навигационного свойства к Portfolio
            .HasForeignKey(o => o.PortfolioId)
            .OnDelete(DeleteBehavior.Cascade); // Удалить операции при удалении портфеля
    }
}
