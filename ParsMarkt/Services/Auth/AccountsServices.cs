using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ViewModels;

namespace ParsMarkt
{
    public class AccountsServices : BaseServices,IAccountsServices
    {

        public AccountsServices(HttpClient client):base(client)
        {

        }
        public string Url;
        public Task<UserToken> Login(LoginViewModel viewModel)
        {
            Url = "signin";
            RequestUri = $"{BaseUrl}/{GetApiUrl()}/{Url}";
            try
            {
                var res = PostAsync<LoginViewModel,UserToken>(viewModel);
                if (res!=null)
                {
                    return res;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return default;
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        public async Task<RegisterViewModel> Resister(RegisterViewModel viewModel)
        {
            Url = "Create";
            RequestUri = $"{BaseUrl}/{GetApiUrl()}/{Url}";
           
            var res = await PostAsync<RegisterViewModel,UserToken>(viewModel);
            if (res==null)
            {
                return viewModel;
            }
            return viewModel;
        }
        protected override string GetApiUrl()
        {
            return $"accounts";
        }
    }
}
