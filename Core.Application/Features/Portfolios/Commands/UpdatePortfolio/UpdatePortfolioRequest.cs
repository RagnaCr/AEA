using System.ComponentModel.DataAnnotations;


namespace Core.Application.Features.Portfolios.Commands.UpdatePortfolio;

// Модель с данными, которые клиент может изменять.
public class UpdatePortfolioRequest
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
}