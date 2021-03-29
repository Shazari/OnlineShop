using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
namespace ParsMarkt.Pages.Auth
{
    public partial class Login
    {
        public Login()
        {
            loginViewModel = new LoginViewModel();
        }
        private LoginViewModel loginViewModel { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IAccountsServices AccountServices { get; set; }

        [Inject]
        public ILoginServices LoginServices { get; set; }
        private string LoginMessage = "";
        protected override async Task OnInitializedAsync()
        {
        }
        public async Task SignIn()
        {
            try
            {
                var userToken = await AccountServices.Login(loginViewModel);
                await LoginServices.Login(userToken.Token);
                NavigationManager.NavigateTo("/");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }

    }
}
