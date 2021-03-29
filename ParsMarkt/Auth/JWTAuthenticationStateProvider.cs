using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ViewModels;
using Blazored.LocalStorage;
using System.Security.Claims;
using System.Text.Json;

namespace ParsMarkt
{
    public class JWTAuthenticationStateProvider : AuthenticationStateProvider, ILoginServices
    {
       

        [Inject]
        public LocalStorageService LocalStorage { get; set; }

        private readonly HttpClient httpClient;
        private readonly string TokenKey = "Token";

        private AuthenticationState Anonymous => new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

        public JWTAuthenticationStateProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await LocalStorage.GetItemAsync<string>(TokenKey);

            if (string.IsNullOrEmpty(token))
            {
                return Anonymous;
            }
            return BuildAuthenticationState(token);
        }

        public AuthenticationState BuildAuthenticationState(string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt")));
        }


        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));
            return claims;
        }
        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
        public async Task Login(string Token)
        {
            await LocalStorage.SetItemAsync<string>(TokenKey, Token);
            var authState = BuildAuthenticationState(Token);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));

        }

        public async Task LogOut()
        {
            await LocalStorage.RemoveItemAsync(TokenKey);
            httpClient.DefaultRequestHeaders.Authorization = null;
            NotifyAuthenticationStateChanged(Task.FromResult(Anonymous));
        }

        public Task TryRenewToken()
        {
            throw new NotImplementedException();
        }
    }
}
