using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using ViewModels;
namespace ParsMarkt.Pages.Auth
{
    public partial class Register
    {

        [Inject]
        public IAccountsServices AccountServices { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private RegisterViewModel registerViewModel;
        private string RegisterErrorMessage;
        protected override async Task OnInitializedAsync()
        {
            registerViewModel = new RegisterViewModel();
        }
        protected async Task HandleValidSubmit()
        {
            if (!string.IsNullOrEmpty(registerViewModel.Email) && !string.IsNullOrEmpty(registerViewModel.Password))
            {
                try
                {
                    
                    var res = await AccountServices.Resister(registerViewModel);
                    if (res==null)
                    {
                        RegisterErrorMessage = "Email exist";
                        NavigationManager.NavigateTo("register");
                    }
                    else
                    {
                        NavigationManager.NavigateTo("/");
                    }

                }
                catch (Exception e)
                {

                   // throw new Exception(e.Message);
                }
            }
        }
    }
}
