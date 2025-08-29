// SimpleMediator/ISender.cs
using System.Threading;
using System.Threading.Tasks;

namespace MediatR
{
    public interface ISender
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);

        // Эта перегрузка нужна для IRequest без TResponse (т.е. IRequest<Unit>)
        // Но благодаря ковариантности, достаточно одной. Для простоты оставим одну.
        // Task Send(IRequest request, CancellationToken cancellationToken = default);
    }
}

// SimpleMediator/IMediator.cs
namespace MediatR
{
    // В этой версии IMediator будет просто синонимом ISender.
    public interface IMediator : ISender
    {
    }
}