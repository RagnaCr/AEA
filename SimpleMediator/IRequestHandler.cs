// SimpleMediator/IRequestHandler.cs
using System.Threading;
using System.Threading.Tasks;

namespace MediatR
{
    // Базовый интерфейс обработчика
    public interface IBaseRequestHandler { }

    // Для обработчиков, возвращающих результат
    public interface IRequestHandler<in TRequest, TResponse> : IBaseRequestHandler
        where TRequest : IRequest<TResponse>
    {
        Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }

    // Для обработчиков, НЕ возвращающих результат
    public interface IRequestHandler<in TRequest> : IRequestHandler<TRequest, Unit>
        where TRequest : IRequest<Unit>
    {
    }
}