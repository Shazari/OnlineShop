using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace ParsMarkt.Shared.Header
{
    public partial class NewHeader
    {
        public NewHeader()
        {
            registerViewModel = new RegisterViewModel();
            loginViewModel = new LoginViewModel();
            personInfo = new List<PersonViewModel>();
        }

        [Inject]
        public IPersonServices PersonService { get; set; }
        [Inject]
        public ILocalStorageService LocalStorage { get; set; }
        
        private RegisterViewModel registerViewModel;
        private LoginViewModel loginViewModel;
        private IList<PersonViewModel> personInfo;
        private string registerdeMessage;
        private string loginMessage;

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //var userInfo = await LocalStorage.GetItemAsync<List<LoginViewModel>>("Users");
            var res =  await PersonService.GetAsync();
            personInfo = res.ToList();

        }
        
        protected async Task HandleValidSubmit()
        {
            var isRegistered = personInfo.Any(p => p.EmailAddress.ToLower() == registerViewModel.EmailAddress.ToLower());
            if (!isRegistered)
            {
                if (registerViewModel.EmailAddress != null && registerViewModel.Password != null)
                {
                    //await PersonService.PostAsync();
                    registerdeMessage = "login kon";


                }

            }
        }

        public async Task Register()
        {
            var isRegistered = personInfo.Any(p => p.EmailAddress.ToLower() == registerViewModel.EmailAddress.ToLower());
            if (!isRegistered)
            {
                if (registerViewModel.EmailAddress != null && registerViewModel.Password != null)
                {
                    await PersonService.PostAsync(new PersonViewModel { EmailAddress = registerViewModel.EmailAddress, Password = registerViewModel.Password });
                    registerdeMessage = "login kon";


                }

            }
            registerdeMessage = "register hassi Amoo boro be login";

            NavigationManager.NavigateTo("Home");



        }
        public void Login()
        {
            var passCheck = personInfo.Any(p=>p.Password==loginViewModel.Password);
            var checkEmail = personInfo.Any(p=>p.EmailAddress==loginViewModel.EmailAddress);
            if (passCheck&&checkEmail)
            {
                loginMessage = "login shodid";

            }
            else
            {
                loginMessage = "nashod ke beshe";
            }

        }

    }
}
