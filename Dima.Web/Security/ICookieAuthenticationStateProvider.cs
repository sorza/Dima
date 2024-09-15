using Microsoft.AspNetCore.Components.Authorization;

namespace Dima.Web.Security
{
    public interface ICookieAuthenticationStateProvider
    {
        Task<bool> CheckAuthenticationAsync();
        Task<AuthenticationState> AuthenticationStateAsync();
        void NotifyAuthenticationStateChanged();
    }
}
