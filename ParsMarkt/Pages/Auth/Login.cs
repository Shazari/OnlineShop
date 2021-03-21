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

        private string LoginMessage = "";
        protected override async Task OnInitializedAsync()
        {
            
        }
        public async Task SignIn()
        {
            try
            {
                var res = await AccountServices.Login(loginViewModel);
                if (res != null)
                {
                    LoginMessage = "login succeded";
                    NavigationManager.NavigateTo($"{NavigationManager.Uri}", forceLoad: false);
                }
                else
                {
                    LoginMessage = "Login Faild";
                    NavigationManager.NavigateTo($"{NavigationManager.BaseUri}", forceLoad: false);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
           
        }

    }
}
