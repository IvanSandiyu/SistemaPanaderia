using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Security.Claims;

namespace Panaderia.Blazor.Services
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private const string StorageKey = "panaderia_usuario";

        private readonly IJSRuntime _js;

        public AuthStateProvider(IJSRuntime js)
        {
            _js = js;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var usuario = await _js.InvokeAsync<string>("localStorage.getItem", StorageKey);

            if (string.IsNullOrWhiteSpace(usuario))
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

            return new AuthenticationState(new ClaimsPrincipal(CrearIdentidad(usuario)));
        }

        public async Task MarcarComoAutenticado(string usuario)
        {
            await _js.InvokeVoidAsync("localStorage.setItem", StorageKey, usuario);

            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(new ClaimsPrincipal(CrearIdentidad(usuario)))));
        }

        public async Task MarcarComoDesautenticado()
        {
            await _js.InvokeVoidAsync("localStorage.removeItem", StorageKey);

            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()))));
        }

        private static ClaimsIdentity CrearIdentidad(string usuario)
        {
            return new ClaimsIdentity(
                new[] { new Claim(ClaimTypes.Name, usuario) },
                authenticationType: "panaderia");
        }
    }
}
