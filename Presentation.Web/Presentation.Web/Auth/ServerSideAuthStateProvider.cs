using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Presentation.Web.Auth
{
    // Этот провайдер работает ТОЛЬКО на сервере во время первоначальной загрузки.
    // Его единственная задача - предоставить анонимное состояние, чтобы приложение не упало.
    public class ServerSideAuthStateProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // На сервере мы всегда считаем пользователя анонимным.
            // Реальное состояние придет с клиента после загрузки WebAssembly.
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            return Task.FromResult(new AuthenticationState(anonymousUser));
        }
    }
}
