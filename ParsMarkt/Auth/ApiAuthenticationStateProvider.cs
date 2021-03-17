using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ParsMarkt
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var anonymouse = new ClaimsIdentity(new List<Claim>()
            {
                new Claim("Key1","Value1"),
                new Claim(ClaimTypes.Name,"Askar"),
                new Claim(ClaimTypes.Role,"Admin")
            }, "test");
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymouse)));
        }
    }
}
