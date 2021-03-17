using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace ParsMarkt
{
    public class JWTAuthenticationStateProvider : AuthenticationStateProvider,ILoginServices
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            throw new NotImplementedException();
        }

        public Task Login(UserToken userToken)
        {
            throw new NotImplementedException();
        }

        public Task LogOut()
        {
            throw new NotImplementedException();
        }

        public Task TryRenewToken()
        {
            throw new NotImplementedException();
        }
    }
}
