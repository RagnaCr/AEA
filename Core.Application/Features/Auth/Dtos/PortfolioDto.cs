using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.Auth.Dtos;
public class PortfolioDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    // В будущем можно добавить сюда вычисляемые поля,
    // например, CurrentValue, TotalProfitLoss и т.д.
}