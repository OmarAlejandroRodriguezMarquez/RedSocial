using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using RedSocial.Client.Auth;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace RedSocial.Client.Auth
{
    public class Autenticacion : AuthenticationStateProvider, ILoginService
    {
        public Autenticacion(IJSRuntime js, HttpClient client)
        {
            this.js = js;
            this.client = client;
        }

        public static readonly string TOKENKEY = "TokenRedSocial";
        private readonly IJSRuntime js;
        private readonly HttpClient client;

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            var token = await js.ObtenerDeLocalStorage(TOKENKEY);
            if(token is null)
            {
                Console.WriteLine("sin token");
            }

            return ConstruirAuthenticationState(token.ToString()!);
        }

        private AuthenticationState ConstruirAuthenticationState(string token)
        {
            client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("bearer", token);
            var claims = ObtenerClaims(token);
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt")));
        }

        private IEnumerable<Claim> ObtenerClaims(string token)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenDeserializado = jwtSecurityTokenHandler.ReadJwtToken(token);
            return tokenDeserializado.Claims;
        }

        public async Task Login(string token)
        {
            await js.GuardarEnLocalStorage(TOKENKEY, token);
            var authState = ConstruirAuthenticationState(token);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        public async Task Logout()
        {
            await js.RemoverDelLocalStorage(TOKENKEY);
            client.DefaultRequestHeaders.Authorization = null;
        }
    }
}
