using Core.Application.Features.Auth.Dtos;
using MediatR;

namespace Core.Application.Features.Portfolios.Commands.Queries;
// Этот запрос будет нести ID пользователя и ожидает в ответ список DTO
public class GetAllPortfoliosQuery : IRequest<List<PortfolioDto>>
{
    public Guid UserId { get; set; }
}
