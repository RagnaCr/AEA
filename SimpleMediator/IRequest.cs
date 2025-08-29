// SimpleMediator/IRequest.cs
namespace MediatR
{
    // Для запросов, возвращающих результат
    public interface IRequest<out TResponse> : IBaseRequest { }

    // Для запросов, не возвращающих результат (как IRequest<Unit>)
    public interface IRequest : IRequest<Unit> { }
}