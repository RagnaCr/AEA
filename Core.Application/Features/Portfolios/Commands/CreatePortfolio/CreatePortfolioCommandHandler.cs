using Core.Application.Common.Interfaces;
using Core.Domain.Entity;
using MediatR;

namespace Core.Application.Features.Portfolios.Commands.CreatePortfolio;

public class CreatePortfolioCommandHandler : IRequestHandler<CreatePortfolioCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    // Мы запрашиваем зависимость от ИНТЕРФЕЙСА, а не от конкретной реализации
    public CreatePortfolioCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreatePortfolioCommand request, CancellationToken cancellationToken)
    {
        // 1. Создаем сущность домена, используя конструктор из Core.Domain
        var portfolio = new Portfolio(request.UserId, request.Name);

        // 2. Добавляем ее в контекст данных
        _context.Portfolios.Add(portfolio);

        // 3. Сохраняем изменения в базе данных
        await _context.SaveChangesAsync(cancellationToken);

        // 4. Возвращаем ID созданной сущности
        return portfolio.Id;
    }
}