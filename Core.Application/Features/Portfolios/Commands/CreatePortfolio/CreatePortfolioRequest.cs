using System.ComponentModel.DataAnnotations;

namespace Core.Application.Features.Portfolios.Commands.CreatePortfolio;
public class CreatePortfolioRequest
{
    [Required]
    public string Name { get; set; }
}
