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
        protected override string GetApiUrl()
        {
            return "accounts/signin";
        }
        public Task<LoginViewModel> Login(LoginViewModel viewModel)
        {
            try
            {
                var res = PostAsync<LoginViewModel,LoginViewModel>(viewModel);
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
           // var content = new StringContent(JsonSerializer.Serialize(viewModel), Encoding.UTF8, "application/json");
            //string verb = "register";
            //RequestUri =$"{ BaseUrl}/{GetApiUrl()}/{verb}";
            //HttpClient client = new HttpClient();
           // var res=await client.PostAsync(RequestUri,content);
            var res = await PostAsync<RegisterViewModel,RegisterViewModel>(viewModel);
            if (res==null)
            {
                return viewModel;
            }
            return viewModel;
        }
    }
}
