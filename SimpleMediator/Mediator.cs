// SimpleMediator/Mediator.cs
using MediatR; // Теперь это using нашего же пространства имен!

namespace SimpleMediator.Implementation // Используем другое пространство имен для реализации
{
    public class Mediator : IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public Mediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            // Получаем тип обработчика, например IRequestHandler<CreatePortfolioCommand, Guid>
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));

            // Разрешаем его из DI
            var handler = _serviceProvider.GetService(handlerType);

            if (handler == null)
            {
                throw new InvalidOperationException($"Handler for request '{request.GetType().Name}' returning '{typeof(TResponse).Name}' was not found.");
            }

            // Динамически вызываем метод Handle
            // Это можно оптимизировать с помощью Expression Trees
            var handleMethod = handler.GetType().GetMethod("Handle");

            return (Task<TResponse>)handleMethod.Invoke(handler, new object[] { request, cancellationToken });
        }
    }
}