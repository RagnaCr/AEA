// SimpleMediator/ServiceCollectionExtensions.cs
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

// Положим его в свое пространство имен, чтобы точно знать, что вызываем.
namespace SimpleMediator
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services, params Assembly[] assembliesToScan)
        {
            // Регистрируем нашу реализацию
            services.AddScoped<IMediator, Implementation.Mediator>();
            services.AddScoped<ISender>(sp => sp.GetRequiredService<IMediator>());

            // Находим и регистрируем все обработчики
            var handlerTypes = assembliesToScan
                .SelectMany(a => a.GetTypes())
                .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
                .ToList();

            foreach (var type in handlerTypes)
            {
                var interfaces = type.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>));

                foreach (var iface in interfaces)
                {
                    services.AddScoped(iface, type);
                }
            }

            return services;
        }
    }
}