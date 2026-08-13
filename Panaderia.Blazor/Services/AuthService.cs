namespace Panaderia.Blazor.Services
{
    public class AuthService
    {
        private readonly AuthStateProvider _authStateProvider;

        public AuthService(AuthStateProvider authStateProvider)
        {
            _authStateProvider = authStateProvider;
        }

        public async Task<bool> Login(string usuario, string contrasena)
        {
            if (usuario != "admin" || contrasena != "admin1234")
                return false;

            await _authStateProvider.MarcarComoAutenticado(usuario);
            return true;
        }

        public async Task Logout()
        {
            await _authStateProvider.MarcarComoDesautenticado();
        }
    }
}
