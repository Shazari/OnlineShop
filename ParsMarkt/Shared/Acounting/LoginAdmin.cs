using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace ParsMarkt.Shared.Acounting
{
    public partial class LoginAdmin
    {
        public LoginAdmin()
        {
            loginViewModel = new  LoginViewModel();
        }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        
        

        public LoginViewModel loginViewModel;
        protected void Login()
        {
            NavigationManager.NavigateTo("AdminHome");
        }
    }
}
